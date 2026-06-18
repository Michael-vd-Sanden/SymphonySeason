using System.Collections.Generic;
using UnityEngine;

public class NoteSetter : MonoBehaviour
{
    [Header("-------------- Changeble Values")]
    [SerializeField] private BlockPuzzleManager manager;


    [Header("-------------- Background Values (do not change)")]
    public List<int> noteIndexes;

    public void CheckNoteIndex(string note, List<int> list)
    {
        switch (manager.category)
        {
            case TheoryCategory.NoteNames:
                Notenames(note, list);
                break;
            case TheoryCategory.Chords: 
                Chords(note, list);
                break;
            default: 
                break;
        }
    }

    private void Notenames(string note, List<int> list)
    {
        switch (note)
        {
            case "C":
                list.Add(0);
                list.Add(1);
                break;
            case "C#":
                list.Add(2);
                list.Add(3);
                break;
            case "Db":
                list.Add(4);
                list.Add(5);
                break;
            case "D":
                list.Add(6);
                list.Add(7);
                break;
            case "D#":
                list.Add(8);
                list.Add(9);
                break;
            case "Eb":
                list.Add(10);
                list.Add(11);
                break;
            case "E":
                list.Add(12);
                list.Add(13);
                break;
            case "F":
                list.Add(14);
                list.Add(15);
                break;
            case "F#":
                list.Add(16);
                list.Add(17);
                break;
            case "Gb":
                list.Add(18);
                list.Add(19);
                break;
            case "G":
                list.Add(20);
                list.Add(21);
                break;
            case "G#":
                list.Add(22);
                list.Add(23);
                break;
            case "Ab":
                list.Add(24);
                break;
            case "A":
                list.Add(25);
                break;
            case "A#":
                list.Add(26);
                break;
            case "Bb":
                list.Add(27);
                break;
            case "B":
                list.Add(28);
                break;
        }
    }

    private void Chords(string note, List<int> list)
    {
        switch (note)
        {
            case "C":
                list.Add(1);
                list.Add(13);
                list.Add(21);
                break;
            case "C#":
                list.Add(3);
                list.Add(15);
                list.Add(23);
                break;
            case "Db":
                list.Add(5);
                list.Add(15);
                list.Add(24);
                break;
            case "D":
                list.Add(7);
                list.Add(17);
                list.Add(25);
                break;
            case "D#":
                list.Add(9);
                list.Add(21);
                list.Add(26);
                break;
            case "Eb":
                list.Add(11);
                list.Add(21);
                list.Add(27);
                break;
            case "E":
                list.Add(13);
                list.Add(23);
                list.Add(28);
                break;
            case "F":
                list.Add(15);
                list.Add(25);
                list.Add(0);
                break;
            case "F#":
                list.Add(17);
                list.Add(26);
                list.Add(2);
                break;
            case "Gb":
                list.Add(19);
                list.Add(27);
                list.Add(4);
                break;
            case "G":
                list.Add(21);
                list.Add(28);
                list.Add(6);
                break;
            case "G#":
                list.Add(23);
                list.Add(0);
                list.Add(8);
                break;
            case "Ab":
                list.Add(24);
                list.Add(0);
                list.Add(10);
                break;
            case "A":
                list.Add(25);
                list.Add(2);
                list.Add(12);
                break;
            case "A#":
                list.Add(26);
                list.Add(6);
                list.Add(14);
                break;
            case "Bb":
                list.Add(27);
                list.Add(6);
                list.Add(14);
                break;
            case "B":
                list.Add(28);
                list.Add(8);
                list.Add(16);
                break;
        }
    }
}
