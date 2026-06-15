using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private AudioClip[] effectClips;
    [SerializeField] private AudioClip[] ambientClips;
    public AudioSource musicSource, effectSource;

    private int activeMusicClip = 0;
    private int activeEffectClip = 0; 

    private void Update()
    {
        if(!musicSource.isPlaying) 
        { PlayMusic(); }
    }

    public void PlayMusic()
    {
        if (activeMusicClip < ambientClips.Length)
        {
            musicSource.clip = ambientClips[activeMusicClip];
            activeMusicClip++;
        }
        else
        {
            activeMusicClip = 0;
            musicSource.clip = ambientClips[activeMusicClip];
        }
        musicSource.Play();
    }

    public void PlayEffect(string effectName, TheoryCategory theory)
    {
        if (theory == TheoryCategory.NoteNames)
        {
            switch (effectName)
            {
                case "Wrong": activeEffectClip = 0; break;
                case "A": activeEffectClip = 1; break;
                case "A#":
                case "Bb": activeEffectClip = 2; break;
                case "B": activeEffectClip = 3; break;
                case "C": activeEffectClip = 4; break;
                case "C#":
                case "Db": activeEffectClip = 5; break;
                case "D": activeEffectClip = 6; break;
                case "D#":
                case "Eb": activeEffectClip = 7; break;
                case "E": activeEffectClip = 8; break;
                case "F": activeEffectClip = 9; break;
                case "F#":
                case "Gb": activeEffectClip = 10; break;
                case "G": activeEffectClip = 11; break;
                case "G#":
                case "Ab": activeEffectClip = 12; break;
            }
        }
        else if (theory == TheoryCategory.Chords)
        {
            switch (effectName)
            {
                case "Wrong": activeEffectClip = 0; break;
                case "A": activeEffectClip = 13; break;
                case "A#":
                case "Bb": activeEffectClip = 14; break;
                case "B": activeEffectClip = 15; break;
                case "C": activeEffectClip = 16; break;
                case "C#":
                case "Db": activeEffectClip = 17; break;
                case "D": activeEffectClip = 18; break;
                case "D#":
                case "Eb": activeEffectClip = 19; break;
                case "E": activeEffectClip = 20; break;
                case "F": activeEffectClip = 21; break;
                case "F#":
                case "Gb": activeEffectClip = 22; break;
                case "G": activeEffectClip = 23; break;
                case "G#":
                case "Ab": activeEffectClip = 24; break;
            }
        }
        else { activeEffectClip = 0; }
        effectSource.clip = effectClips[activeEffectClip];
        effectSource.Play();
    }

}
