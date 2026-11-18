using System.Collections;
using UnityEngine;

public class CandleScript : MonoBehaviour
{
    [SerializeField] private GameObject flame;
    public GameObject igniteBtn, extinguishBtn;
    public NoteTypes noteType;
    public float timeOfNote;

    public bool isOn;
    public bool playerIsClose;

    public CandlePuzzelManager puzzelManager;
    public MetronomeScript metronome;

    public void TurnOn()    //called by ignite button in scene
    {
        flame.SetActive(true);
        igniteBtn.SetActive(false);
        extinguishBtn.SetActive(true);

        metronome.CheckNoteTypeLength(this);

        StartCoroutine(Flaming());
    }

    public IEnumerator Flaming()
    {
        yield return new WaitForSecondsRealtime(timeOfNote);
        Debug.Log("Candle is burt out in: " + timeOfNote + " seconds");
        TurnOff();
    }

    public void TurnOff()   //called by extinguish button in scene & Flaming()
    {
        flame.SetActive(false);
        igniteBtn.SetActive(true);
        extinguishBtn.SetActive(false);
    }

}
