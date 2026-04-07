using System.Collections;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private BPUiToggles UiToggles;
    [SerializeField] private MoveUIToggles moveUIToggles;
    [SerializeField] private BlockPuzzleManager manager;

    [Header("-------- Lv 1 & 2")]
    [SerializeField] private Animator cross;
    
    [Header("-------------- Changeble Values")]
    public int tutorialLevel;

    [Header("-------------- Background Values (do not change)")]
    private bool isRunning;

    private void Start()
    {
        CheckTut();
    }

    private void CheckTut()
    {
        switch (tutorialLevel) 
        {
            case 1:
                cross.SetBool("Pulsing", true);
                break;
            case 2:
                cross.SetBool("Pulsing", true);
                break;
        }
    }

    public void PressedHoldWithoutNotes()
    {
        moveUIToggles.TurnOffDirections();
        UiToggles.holdControl.SetActive(false);
        UiToggles.releaseControl.SetActive(true);

        manager.HoldBlock();

        if (manager.enteredBlocks.Count > 1)
        { UiToggles.switchControl.SetActive(true); }
        else
        { UiToggles.switchControl.SetActive(false); }
    }
}
