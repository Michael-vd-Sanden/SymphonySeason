using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CrystalPuzzleManager : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private AudioPlayer audioPlayer;

    [Header("-------------- Changeble Values")]
    public string chord;

    [Header("-------------- Background Values (do not change)")]
    [SerializeField] private bool isCorrect;
    public bool isPlayingAnswer;
    public int[] noteInts;
    public int[] answerInts;


    public void CheckAnswer() 
    {
        if (answerInts.Length == 0) SetAnswer();
        if (noteInts.Length == 0) noteInts = new int[3];

        if (noteInts[0] == answerInts[0] &&
            noteInts[1] == answerInts[1] &&
            noteInts[2] == answerInts[2])
        {//good answer
            Debug.Log("yeey");
            isCorrect= true;
        }
        else
        {//wrong answer
            Debug.Log("Ney");
            isCorrect= false;
        }
    }

    private void SetAnswer()
    {
        answerInts = new int[3];
        int startNote = 0;
        switch (chord)
        {
            case "A": startNote = 0; break;
            case "A#":
            case "Bb": startNote = 1; break;
            case "B": startNote = 2; break;
            case "C": startNote = 3; break;
            case "C#":
            case "Db": startNote = 4; break;
            case "D": startNote = 5; break;
            case "D#":
            case "Eb": startNote = 6; break;
            case "E": startNote = 7; break;
            case "F": startNote = 8; break;
            case "F#":
            case "Gb": startNote = 9; break;
            case "G": startNote = 10; break;
            case "G#":
            case "Ab": startNote = 11; break;
        }

        //het antwoord
        answerInts[0] = startNote;
        answerInts[1] = startNote + 4;
        answerInts[2] = startNote + 7;
    }

    public IEnumerator PlayChordNotes()
    {
        isPlayingAnswer = true;
        for (int i = 0; i < answerInts.Length; i++)
        {
            audioPlayer.PlayEffect(IntToNote(noteInts[i]), TheoryCategory.NoteNames);
            yield return new WaitForSecondsRealtime(0.75f);
        }
        if(isCorrect) { audioPlayer.PlayEffect(chord, TheoryCategory.Chords); }
        else { audioPlayer.PlayEffect("Wrong", TheoryCategory.Chords); }
        yield return new WaitForSecondsRealtime(0.75f);
        isPlayingAnswer = false;
    }

    private string IntToNote(int i)
    {
        string note;
        switch (i)
        {
            case 0: note = "A"; break;
            case 1: note = "Bb"; break;
            case 2: note = "B"; break;
            case 3: note = "C"; break;
            case 4: note = "Db"; break;
            case 5: note = "D"; break;
            case 6: note = "Eb"; break;
            case 7: note = "E"; break;
            case 8: note = "F"; break;
            case 9: note = "Gb"; break;
            case 10: note = "G"; break;
            case 11: note = "Ab"; break;
            default: note = "A"; break;
        }
        return note;
    }

    public void SetNoteInts(int crystalID, int noteInt)
    {
        if(noteInts.Length == 0) noteInts = new int[3];
        switch (crystalID)
        {
            case 0:
                noteInts[0] = noteInt; break;
            case 1:
                noteInts[1] = noteInt; break;
            case 2:
                noteInts[2] = noteInt; break;
        }
    }

}
