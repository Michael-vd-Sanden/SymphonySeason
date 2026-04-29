using System.Collections;
using UnityEngine;

public class BPUiToggles : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private BlockPuzzleManager manager;
    [SerializeField]
    private GameObject nextLevelScreen, btnSwitchFlSH, baseNoteBtns;
    public GameObject holdControl, releaseControl, switchControl;
    [SerializeField] private GameObject[] noteBtnsObjects;

    public void EnteredTrigger()
    {
        holdControl.SetActive(true);
    }

    public void ExitedTrigger() 
    { 
        holdControl.SetActive(false);
        baseNoteBtns.SetActive(false);
        foreach(GameObject g in noteBtnsObjects) { g.SetActive(false); }
    }

    public void DeactivateNoteBtns()
    {
        baseNoteBtns.SetActive(false) ;
        foreach (GameObject g in noteBtnsObjects) { g.SetActive(false); }
    }

    public void PressedHoldBtn()
    {
        if (btnSwitchFlSH != null) { btnSwitchFlSH.SetActive(true); }
        holdControl.SetActive(false);
        releaseControl.SetActive(true);
        baseNoteBtns.SetActive(true);
        foreach (GameObject g in noteBtnsObjects) { g.SetActive(true); }
        manager.HoldBlock();

        if (manager.enteredBlocks.Count > 1)
        { switchControl.SetActive(true); }
        else
        { switchControl.SetActive(false); }
    }

    public void ActivateBlockDirections()
    {
        MoveBlockScript block = manager.currentSelectedBlock;
        if(block.upAllowed) { block.pushUpControl.SetActive(true); }
        else { block.pushUpControl.SetActive(false); }
        if(block.downAllowed) { block.pushDownControl.SetActive(true);}
        else { block.pushDownControl.SetActive(false);}

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
        manager.currentSelectedBlock.pushUpControl.SetActive(false);
        manager.currentSelectedBlock.pushDownControl.SetActive(false);

        baseNoteBtns.SetActive(true);
        foreach (GameObject g in noteBtnsObjects) { g.SetActive(true); }
        manager.SwitchBlock();
    }

    public void PressedReleaseBtn()
    {
        manager.currentSelectedBlock.pushUpControl.SetActive(false);
        manager.currentSelectedBlock.pushDownControl.SetActive(false);

        if (btnSwitchFlSH != null) { btnSwitchFlSH.SetActive(false); }
        releaseControl.SetActive(false);
        switchControl.SetActive(false);
        baseNoteBtns.SetActive(false);
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
