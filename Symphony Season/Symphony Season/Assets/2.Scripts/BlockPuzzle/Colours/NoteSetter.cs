using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NoteSetter : MonoBehaviour
{
    [Header("-------------- Background Values (do not change)")]
    public List<int> noteIndexes;

    public void CheckNoteIndex(string note)
    {
        switch (note)
        {
            case "C":
                noteIndexes.Add(0);
                noteIndexes.Add(1);
                break;
            case "C#":
                noteIndexes.Add(2);
                noteIndexes.Add(3);
                break;
            case "Db":
                noteIndexes.Add(4);
                noteIndexes.Add(5);
                break;
            case "D":
                noteIndexes.Add(6);
                noteIndexes.Add(7);
                break;
            case "D#":
                noteIndexes.Add(8);
                noteIndexes.Add(9);
                break;
            case "Eb":
                noteIndexes.Add(10);
                noteIndexes.Add(11);
                break;
            case "E":
                noteIndexes.Add(12);
                noteIndexes.Add(13);
                break;
            case "F":
                noteIndexes.Add(14);
                noteIndexes.Add(15);
                break;
            case "F#":
                noteIndexes.Add(16);
                noteIndexes.Add(17);
                break;
            case "Gb":
                noteIndexes.Add(18);
                noteIndexes.Add(19);
                break;
            case "G":
                noteIndexes.Add(20);
                noteIndexes.Add(21);
                break;
            case "G#":
                noteIndexes.Add(22);
                noteIndexes.Add(23);
                break;
            case "Ab":
                noteIndexes.Add(24);
                break;
            case "A":
                noteIndexes.Add(25);
                break;
            case "A#":
                noteIndexes.Add(26);
                break;
            case "Bb":
                noteIndexes.Add(27);
                break;
            case "B":
                noteIndexes.Add(28);
                break;
        }
    }
}
