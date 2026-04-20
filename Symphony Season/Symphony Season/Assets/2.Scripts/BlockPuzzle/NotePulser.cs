using UnityEngine;
using System.Collections.Generic;
using System;

public class NotePulser : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    public BlockPuzzleManager BlockPuzzleManager;
    public Animator[] NoteAnimators;
    [SerializeField] private NoteSetter noteSetter;

    [Header("-------------- Background Values (do not change)")]
    [SerializeField] private List<int> notePulseIndexes;
    public string note; //van blockpuzzlemanager

    //aangeroepen wanneer je op hold button klikt
    public void NoteShift()
    {
        note = BlockPuzzleManager.currentBlockNote;
        noteSetter.CheckNoteIndex(note, notePulseIndexes);
        foreach (int n in notePulseIndexes)
        { NoteAnimators[n].SetTrigger("Pulsing"); }
    }

    //let go
    public void NoNotes()
    {
        foreach (int n in notePulseIndexes)
        { NoteAnimators[n].SetTrigger("NotPulsing"); }
        notePulseIndexes.Clear();
    }
}
