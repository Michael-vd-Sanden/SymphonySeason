using System;
using UnityEngine;

public class WaterActivator : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private GameObject buttonUI;
    [SerializeField] private AudioPlayer audioPlayer;
    [SerializeField] private CrystalPuzzleManager manager;

    //[Header("-------------- Background Values (do not change)")]

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonUI.SetActive(false);
        }
    }

    public void ActivateWater() //triggerd by waterlever
    {
        if (!manager.isPlayingAnswer)
        {
            manager.CheckAnswer();
            StartCoroutine(manager.PlayChordNotes());
        }
    }
}
