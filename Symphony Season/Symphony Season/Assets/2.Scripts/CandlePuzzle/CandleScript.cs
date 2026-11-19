using System.Collections;
using UnityEngine;

public class CandleScript : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private CandlePuzzelManager puzzelManager;
    [SerializeField] private MetronomeScript metronome;
    [SerializeField] private GameObject flame;
    public GameObject igniteBtn, extinguishBtn;

    [Header("-------------- Changeble Values")]
    public NoteTypes noteType;

    [Header("-------------- Background Values (do not change)")]
    public bool isOn;
    public bool hasBeenOn, isFirstCandle, allowedTimer;
    public float timeOfNote, timeAfterExtinguish;

    private void Update()
    {
        if((hasBeenOn && !isOn) 
            && allowedTimer && !isFirstCandle)
        {
            timeAfterExtinguish += Time.deltaTime;
        }
    }

    public void TurnOn()    //called by ignite button in scene
    {
        isOn = true; hasBeenOn = true;
        flame.SetActive(true);
        igniteBtn.SetActive(false);
        extinguishBtn.SetActive(true);

        metronome.CheckNoteTypeLength(this);
        puzzelManager.CandleTurnedOn(this);

        StartCoroutine(Flaming());
    }

    public IEnumerator Flaming()
    {
        yield return new WaitForSecondsRealtime(timeOfNote);
        Debug.Log("Candle is burt out in: " + timeOfNote + " seconds");
        if(isFirstCandle) { puzzelManager.CheckIfCandlesOut(); }
        TurnOff();
    }

    public void TurnOff()   //called by extinguish button in scene, Flaming() & ResetCandles()
    {
        isOn = false;
        flame.SetActive(false);
        igniteBtn.SetActive(true);
        extinguishBtn.SetActive(false);

       /* while (hasBeenOn) 
        {
            timeAfterExtinguish += Time.deltaTime;
            if (timeAfterExtinguish > puzzelManager.timeDifferenceAllowance) break;
        }*/
    }

    public void ResetCandle()
    {
        isOn = false;
        flame.SetActive(false);
        extinguishBtn.SetActive(false);
        hasBeenOn = false;
        timeAfterExtinguish = 0f;
        isFirstCandle = false;
        allowedTimer = true;
    }

}
