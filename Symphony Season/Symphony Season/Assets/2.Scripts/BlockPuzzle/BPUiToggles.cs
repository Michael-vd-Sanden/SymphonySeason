using System.Collections;
using UnityEngine;

public class BPUiToggles : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private MoveUIToggles moveToggles;
    [SerializeField] private BlockPuzzleManager manager;
    [SerializeField]
    private GameObject nextLevelScreen,
        btnsSharp, btnsFlat, btnSwitchFlSH, noteBtnsCanvas;
    public GameObject holdControl, releaseControl, switchControl;
    [SerializeField] private GameObject[] noteBtnsObjects;

    public void EnteredTrigger()
    {
        holdControl.SetActive(true);
    }

    public void ExitedTrigger() 
    { 
        holdControl.SetActive(false);
        noteBtnsCanvas.SetActive(false);
        foreach(GameObject g in noteBtnsObjects) { g.SetActive(false); }
    }

    public void DeactivateNoteBtns()
    {
        noteBtnsCanvas.SetActive(false) ;
        foreach (GameObject g in noteBtnsObjects) { g.SetActive(false); }
    }

    public void SwitchSharpOrSflat()
    {
        btnsFlat.SetActive(!btnsFlat.activeSelf);
        btnsSharp.SetActive(!btnsSharp.activeSelf);
    }

    public void PressedHoldBtn()
    {
        moveToggles.TurnOffDirections();
        if (btnSwitchFlSH != null) { btnSwitchFlSH.SetActive(true); }
        holdControl.SetActive(false);
        releaseControl.SetActive(true);
        noteBtnsCanvas.SetActive(true);
        foreach (GameObject g in noteBtnsObjects) { g.SetActive(true); }
        manager.HoldBlock();

        if (manager.enteredBlocks.Count > 1)
        { switchControl.SetActive(true); }
        else
        { switchControl.SetActive(false); }
    }

    public void ActivateBlockDirections()
    {
        moveToggles.TurnOffDirections();

        MoveBlockScript block = manager.currentSelectedBlock;
        if (block.isRightDirection)
        { //right up direction
            if (block.upAllowed)
            { moveToggles.ActivatePlayerDirections("RightUp", true); }
            if (block.downAllowed)
            { moveToggles.ActivatePlayerDirections("LeftDown", true); }      
        }
        else
        {//left up direction
            if (block.upAllowed)
            { moveToggles.ActivatePlayerDirections("LeftUp", true); }
            if (block.downAllowed)
            { moveToggles.ActivatePlayerDirections("RightDown", true); }
        }

        switch(block.moveDirection)
        {
            case "RightUp":
                if(block.isRightDirection && !block.upAllowed) { block.isPressingBlockMove = false; }
                break;
            case "LeftUp":
                if(!block.isRightDirection && !block.upAllowed) { block.isPressingBlockMove = false; }
                break;
            case "RightDown":
                if(!block.isRightDirection && !block.downAllowed) { block.isPressingBlockMove = false;}
                break;
            case "LeftDown":
                if(block.isRightDirection && !block.downAllowed) { block.isPressingBlockMove = false;}
                break;
        }

        if (manager.enteredBlocks.Count > 1)
        { switchControl.SetActive(true); }
        else
        { switchControl.SetActive(false); }
        manager.currentSelectedBlock.checkedDirections = true;
    }

    public void PressedSwitchBtn()
    {
        //Debug.Log("pressed switch");
        moveToggles.TurnOffDirections();
        noteBtnsCanvas.SetActive(true);
        foreach (GameObject g in noteBtnsObjects) { g.SetActive(true); }
        manager.SwitchBlock();
    }

    public void PressedReleaseBtn()
    {
        if (btnSwitchFlSH != null) { btnSwitchFlSH.SetActive(false); }
        moveToggles.TurnOffDirections();
        releaseControl.SetActive(false);
        switchControl.SetActive(false);
        noteBtnsCanvas.SetActive(false);
        foreach (GameObject g in noteBtnsObjects) { g.SetActive(false); }
        holdControl.SetActive(true);

        manager.LetGoOfBlock();
    }

    public void PressedNoteBtn(string note)
    {
        manager.noteSelected = note;
    }

    public void Victory()
    { 
        nextLevelScreen.SetActive(true) ;
    }
}
