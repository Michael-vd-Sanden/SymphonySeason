using System;
using UnityEngine;
using UnityEngine.UI;

public class CrystalUIScript : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private GameObject sliderUI;  
    [SerializeField] private GameObject btnOn, btnOff;
    [SerializeField] private CrystalMoverScript moverScript;

    [Header("-------------- Background Values (do not change)")]
    public TouchInput playerMovement;
    [SerializeField] private int noteInt;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            btnOn.SetActive(true);
            btnOff.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            btnOn.SetActive(false);
            btnOff.SetActive(false);
            sliderUI.SetActive(false);
        }
    }

    public void SliderOn()
    {
        playerMovement.enabled = false;
        sliderUI.SetActive(true);
        btnOn.SetActive(false);
        btnOff.SetActive(true);
    }

    public void SliderOff()
    {
        playerMovement.enabled = true;
        sliderUI.SetActive(false);
        btnOn.SetActive(true);
        btnOff.SetActive(false);
    }

    public void MoveCrystal(Slider slider)
    {
        noteInt = Convert.ToInt32(slider.value);
        moverScript.MoveCrystal(noteInt);
    }
}
