using UnityEngine;

public class LvUIController : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    public Animator[] dioramaAnimators;
    [SerializeField] private GameObject upBtn, downBtn;
    [SerializeField] private LevelTextChanger floorText;
    [SerializeField] private TextureChanger levelTextures;
    [SerializeField] private MoveObject moveCamera;
    [SerializeField] private LevelIndex lvIndex;

    [Header("-------------- Background Values (do not change)")]
    public bool isRunning;

    private void Update()
    {
        if(isRunning) 
        { 
            if(!moveCamera.isMoving) { isRunning= false; }
        }
    }

    public void LevelShift(int shift)
    {
        if (!isRunning)
        {
            isRunning = true;
            var prevFloorIndex = lvIndex.floorIndex;
            lvIndex.floorIndex += shift;
            Debug.Log(lvIndex.floorIndex);
            if (lvIndex.floorIndex <= 0)
            { 
                lvIndex.floorIndex = 0;
                downBtn.SetActive(false);
            }
            else if (lvIndex.floorIndex >= lvIndex.floorMaximum)
            {   
                lvIndex.floorIndex = lvIndex.floorMaximum;
                upBtn.SetActive(false);
            }
            else
            {
                downBtn.SetActive(true);
                upBtn.SetActive(true);
            }

            floorText.LevelTextShift(lvIndex.floorIndex);
            if (lvIndex.floorIndex != prevFloorIndex) { dioramaAnimators[prevFloorIndex].SetTrigger("NotPulsing"); }
            dioramaAnimators[lvIndex.floorIndex].SetTrigger("Pulsing");
            levelTextures.TextureChange();

            isRunning = false;
        }
    }

}
