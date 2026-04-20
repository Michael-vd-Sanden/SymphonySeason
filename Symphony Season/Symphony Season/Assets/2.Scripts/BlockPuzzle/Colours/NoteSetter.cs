using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NoteSetter : MonoBehaviour
{
    [Header("-------------- Background Values (do not change)")]
    public List<int> noteIndexes;

    public void CheckNoteIndex(string note, List<int> list)
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
}
