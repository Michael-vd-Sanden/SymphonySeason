using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockPuzzleManager : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private BPUiToggles uiToggle;
    [SerializeField] private AudioPlayer audioPlayer;
    [SerializeField] private NotePulser notePulse;
    [SerializeField] private NoteSetter noteSetter;
    [SerializeField] private ColourChanger colourChanger;

    [Header("-------------- Changeble Values")]
    public int hitLayer;
    public TheoryCategory category;
    [SerializeField] private bool isTutorial;
    public GameObject[] noteObjects;

    [Header("-------------- Background Values (do not change)")]
    public int layerAsLayerMask;
    public List<MoveBlockScript> enteredBlocks;
    [SerializeField] private int selectedBlockIndex = 0;
    public MoveBlockScript currentSelectedBlock;
    public string currentBlockAnswer;
    public string answerSelected; //which note btn was pressed
    public Material[] colourMaterials;
    public List<NoteColourChanger> noteColourChangers;
    private bool isCheckingForAnswers = false;

    private void Update()
    {
        if(isCheckingForAnswers) 
        {
            if(currentSelectedBlock== null) { isCheckingForAnswers = false; return; }

            if (answerSelected == currentBlockAnswer) //goede noot
            {
                RightAnswer();
            }
            if(!string.IsNullOrEmpty(answerSelected) && answerSelected != currentBlockAnswer) //foute noot
            {
                //play some sort of sound
                audioPlayer.PlayEffect("Wrong", category);
                //Debug.Log("fout");
                answerSelected = null;
            }
        }
    }

    public void RightAnswer()
    {
        audioPlayer.PlayEffect(answerSelected, category);
        currentSelectedBlock.objectAbleToMove = true;
        currentSelectedBlock.pushUpControl.SetActive(true);
        currentSelectedBlock.pushDownControl.SetActive(true);

        currentSelectedBlock.noteNotification.SetActive(true);
        currentSelectedBlock.questionNotification.SetActive(false);
        CheckIfAllowedToMove();
        answerSelected = null;
        uiToggle.DeactivateNoteBtns();
        isCheckingForAnswers = false;
        if (!isTutorial) { notePulse.NoNotes(); }
        return;
    }

    public void EnteredTrigger(MoveBlockScript block)
    {
        enteredBlocks.Add(block);
        if (enteredBlocks.Count > 0) 
        {
            playerData.canBeOverUI = true;
        }   
        if(enteredBlocks.Count == 1)
        {
            uiToggle.EnteredTrigger();
        }
    }
    public void ExitedTrigger(MoveBlockScript block)
    {
        enteredBlocks.Remove(block);
        if (enteredBlocks.Count == 0) 
        {
            selectedBlockIndex = 0;
            playerData.canBeOverUI= false;
            uiToggle.ExitedTrigger();
        }
    }

    public void HoldBlock()
    {
        if(enteredBlocks.Count > 0) 
        {
            currentSelectedBlock = enteredBlocks[selectedBlockIndex];
            currentBlockAnswer = currentSelectedBlock.blockAnswer;
            currentSelectedBlock.questionNotification.SetActive(true);
            isCheckingForAnswers = true;
            answerSelected = null;
            playerData.isHoldingSomething = true;
            playerData.allowedToMove = false;

            if (category == TheoryCategory.Chords)
            {
                List<int> indexes = new List<int>();
                noteSetter.CheckNoteIndex(currentBlockAnswer, indexes); 
                foreach (int n in indexes) 
                { 
                    noteObjects[n].SetActive(true);
                    //toevoegen dat de colour van alle noten veranderd naar dezelfde kleur
                    noteColourChangers[n].spriteRenderer.material = colourChanger.ChangeColourBasedOnNote(currentBlockAnswer);
                }
            }

            if (!isTutorial && category == TheoryCategory.NoteNames) 
            { notePulse.NoteShift(); }
            if(isTutorial) 
            { 
                isCheckingForAnswers=false;
                RightAnswer();
            }
        }
    }
    public void SwitchBlock()
    {
        LetGoOfBlock();
        //Debug.Log(enteredBlocks.Count.ToString());
        if(enteredBlocks.Count -1 > selectedBlockIndex)
        {
            selectedBlockIndex++;
            currentSelectedBlock = enteredBlocks[selectedBlockIndex];
        }
        else
        {
            selectedBlockIndex = 0;
            currentSelectedBlock = enteredBlocks[selectedBlockIndex];
        }
        HoldBlock();
    }
    public void LetGoOfBlock()
    {
        if (currentSelectedBlock != null)
        {
            currentSelectedBlock.questionNotification.SetActive(false);
            currentSelectedBlock.noteNotification.SetActive(false);
            currentSelectedBlock.objectAbleToMove = false;
            currentSelectedBlock.pushDownControl.SetActive(false);
            currentSelectedBlock.pushUpControl.SetActive(false);

            if (category == TheoryCategory.Chords)
            { for(int i = 0; i < noteObjects.Length; i++) { noteObjects[i].SetActive(false); }}

            currentSelectedBlock = null;
            playerData.isHoldingSomething = false;
            if (!isTutorial) { notePulse.NoNotes(); }
        }
        currentBlockAnswer = null;
        playerData.allowedToMove = true;
        if(!playerData.isMouseMovement)
        { playerData.stoppedMoving = true; }
    }

    public void onPressMove(string direction)
    {
        if (playerData.isHoldingSomething && currentSelectedBlock.objectAbleToMove)
        {
            ///fix met niew ding
            switch (isRight: currentSelectedBlock.isRightDirection, dir: direction)
            {
                case (isRight: true, dir: "Up"):
                    direction = "RightUp";
                    break;
                case (isRight: true, dir: "Down"):
                    direction = "LeftDown";
                    break;
                case (isRight: false, dir: "Up"):
                    direction = "LeftUp";
                    break;
                case (isRight: false, dir: "Down"):
                    direction = "RightDown";
                    break;
            }
            currentSelectedBlock.moveDirection = direction;
            currentSelectedBlock.isPressingBlockMove = true;   
        }
    }

    public void onReleaseMove()
    {
        if (playerData.isHoldingSomething)
        {
            currentSelectedBlock.isPressingBlockMove = false;
        }
    }

    public void SetBlockTargetPos(MoveBlockScript b)
    {//move 1 space
        //Debug.Log("pushed " + direction.ToString());
        if (b.objectAbleToMove && !b.isMoving)
        {
            b.checkedDirections = false;
            b.objectCurrentPos = b.gameObject.transform.position;
            b.playerCurrentPos = b.playerMovement.transform.position;

            b.stepTime = 0f;
            switch (b.moveDirection)
            {
                case "RightUp":
                    b.objectTargetPos = b.objectCurrentPos + new Vector3(1f, 0f, 0f);
                    b.playerTargetPos = b.playerCurrentPos + new Vector3(1f, 0f, 0f);
                    break;
                case "LeftUp":
                    b.objectTargetPos = b.objectCurrentPos + new Vector3(0f, 0f, 1f);
                    b.playerTargetPos = b.playerCurrentPos + new Vector3(0f, 0f, 1f);
                    break;
                case "RightDown":
                    b.objectTargetPos = b.objectCurrentPos + new Vector3(0f, 0f, -1f);
                    b.playerTargetPos = b.playerCurrentPos + new Vector3(0f, 0f, -1f);
                    break;
                case "LeftDown":
                    b.objectTargetPos = b.objectCurrentPos + new Vector3(-1f, 0f, 0f);
                    b.playerTargetPos = b.playerCurrentPos + new Vector3(-1f, 0f, 0f);
                    break;
            }
            b.isMoving = true;
        }
    }

    public void CheckIfAllowedToMove()
    {
        Transform b = currentSelectedBlock.transform;
        for (int check = 0; check < 2; check++)
        {
            Vector3 rayDirect;
            if (check == 0)
            { rayDirect = b.forward; }
            else
            { rayDirect = -b.forward; }

            RaycastHit hit;
            if (Physics.Raycast(b.position, rayDirect, out hit, 3f, layerAsLayerMask))
            {
                Debug.DrawRay(b.position, rayDirect * hit.distance, Color.red, 2f);
                //Debug.Log("object hit: " + hit.transform.name.ToString());

                float allowedDistance;
                if ((currentSelectedBlock.playerIsFront && rayDirect == b.forward) || (!currentSelectedBlock.playerIsFront && rayDirect == -b.forward))
                {// player is in front and moving that direction
                    allowedDistance = currentSelectedBlock.playerDistance;
                }
                else { allowedDistance = currentSelectedBlock.wallDistance; }
                //Debug.Log("allowed distance: " + allowedDistance.ToString());
                //Debug.Log("hit distance: " + hit.distance.ToString());

                if (hit.distance <= allowedDistance)
                {//too close
                    //Debug.Log("too close to move");
                    if(check == 0) { currentSelectedBlock.upAllowed = false; }
                    else { currentSelectedBlock.downAllowed = false; }
                }
                else
                {// able to move
                    if(check == 0) { currentSelectedBlock.upAllowed = true; }
                    else { currentSelectedBlock.downAllowed = true; }   
                }
            }
            else
            {//able to move
                Debug.DrawRay(b.position, rayDirect * 3f, Color.green, 2f);
                if (check == 0) { currentSelectedBlock.upAllowed = true; }
                else { currentSelectedBlock.downAllowed = true; }
            }
        }
        uiToggle.ActivateBlockDirections();
        if(enteredBlocks.Count == 1) { selectedBlockIndex = 0; }
    }
}
