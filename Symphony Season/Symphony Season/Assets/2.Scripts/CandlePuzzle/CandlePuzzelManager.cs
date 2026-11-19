using System.Collections.Generic;
using UnityEngine;

public class CandlePuzzelManager : MonoBehaviour
{
    [SerializeField] private List<CandleScript> candles;

    public float timeDifferenceAllowance;  //hoeveel marge je hebt voor het klikken van de knoppen

    public bool firstCandleOn;

    public void ResetCandles() //called by reset btn in scene
    {
        foreach(CandleScript c in candles) 
        {
            c.ResetCandle();
            firstCandleOn = false;
        }
    }

    public void CandleTurnedOn(CandleScript can)
    {
        if (!firstCandleOn) 
        {
            firstCandleOn = true;
            can.isFirstCandle = true;
        }
    }

    public void CheckIfCandlesOut()
    {
        foreach (CandleScript c in candles) 
        {
            if (!c.isFirstCandle)
            {
                c.allowedTimer = false;     //stopt de timeAfterExtinguish timer
                if (!c.hasBeenOn)      //has every candle been on before?
                {
                    Debug.Log("nog niet aan geweest");
                    break;
                }
                if (c.timeAfterExtinguish > timeDifferenceAllowance || c.timeAfterExtinguish == 0f)     //are they out at the same time?
                {
                    Debug.Log("te lang geleden of nog niet uit");
                    break;
                }
                //all candles are out at the same time and have been on before
                Debug.Log("success");
                break;
            }
        }
    }
}
