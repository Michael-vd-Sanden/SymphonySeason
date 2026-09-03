using System;
using UnityEngine;
using UnityEngine.UI;

public class CrystalUIScript : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private GameObject sliderUI;  
    [SerializeField] private CrystalMoverScript moverScript;
    [SerializeField] private CrystalPuzzleManager manager;

    [Header("-------------- Background Values (do not change)")]
    public TouchInput playerMovement;
    [SerializeField] private int noteInt;
    [SerializeField] private int crystalID;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            sliderUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            sliderUI.SetActive(false);
        }
    }

    public void MoveCrystal(Slider slider)
    {
        noteInt = Convert.ToInt32(slider.value);
        moverScript.MoveCrystal(noteInt);

        manager.SetNoteInts(crystalID, noteInt);
    }
}
