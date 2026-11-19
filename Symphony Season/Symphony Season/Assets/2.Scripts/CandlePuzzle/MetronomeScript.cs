using System.Collections;
using UnityEngine;

public class MetronomeScript : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private AudioSource metronomeSource;

    [Header("-------------- Changeble Values")]
    public int bpm;
    public bool metronomeIsActive;

    [Header("-------------- Background Values (do not change)")]
    [SerializeField] private float timeBetweenNotes;
    private bool reachedEndOfCoroutine = true;

    private void Update()
    {
        if(metronomeIsActive && reachedEndOfCoroutine)
        {
            StartCoroutine(Count());
        }
    }

    public IEnumerator Count()
    {
        while (metronomeIsActive)
        {
            reachedEndOfCoroutine = false;
            timeBetweenNotes = 60f / bpm;

            metronomeSource.Play();

            yield return new WaitForSecondsRealtime(timeBetweenNotes);
            reachedEndOfCoroutine = true;
        }
        StopCoroutine(Count());
    }

    public void CheckNoteTypeLength(CandleScript candle)    
    {   //er nu even vanuitgaande dat het 4/4 is
        switch (candle.noteType)
        {
            case NoteTypes.Sixteenth:
                candle.timeOfNote = timeBetweenNotes / 4f;
                break;
            case NoteTypes.SixteenthDot:
                candle.timeOfNote = timeBetweenNotes / 3f;
                break;
            case NoteTypes.Eighth:
                candle.timeOfNote = timeBetweenNotes / 2f;
                break;
            case NoteTypes.EighthDot:
                candle.timeOfNote = timeBetweenNotes / 1.5f;
                break;
            case NoteTypes.Quarter: 
                candle.timeOfNote = timeBetweenNotes;
                break;
            case NoteTypes.QuarterDot:
                candle.timeOfNote = timeBetweenNotes * 1.5f;
                break;
            case NoteTypes.Half: 
                candle.timeOfNote = timeBetweenNotes * 2f;
                break;
            case NoteTypes.HalfDot:
                candle.timeOfNote = timeBetweenNotes * 3f;
                break;
            case NoteTypes.Whole:
                candle.timeOfNote = timeBetweenNotes * 4f;
                break;
        }
    }
}
