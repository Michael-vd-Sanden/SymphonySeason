using System.Threading.Tasks;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    //This class is added to each tower level selection
    [SerializeField] private LevelIndex levelIndex;     //Might be replaced in future
    [SerializeField] private LevelHolder levelHolder;
    [SerializeField] private SceneSwitching sceneSwitching;
    [SerializeField] private TriggerSetter transitionSetter;
    
    [Header("-------------- Changeble Values")]
    public LevelData[] levelData;
    //level container is structured as (easy lv, hard lv, easy lv, hard lv...)
    //so easy levels are on the even (start at 0) and hard levels are uneven

    [SerializeField] private bool hasTransition;
    [SerializeField] private float transitionWaitTime;

    [Header("-------------- Background Values (do not change)")]
    public LevelData currentLv;
    public bool isHard = false;   //changed while turning level
    private int currentLvInt;        //changed while selecting level (now through levelindex)

    public async void ChangeLevel()       //called on play level btn
    {
        int difficultyAdditive = 0;         // depending on easy or hard
        int difficultyMultiplier = 2;       // always
        if (isHard)
        { difficultyAdditive = 1; }

        currentLvInt = (levelIndex.floorIndex * difficultyMultiplier) + difficultyAdditive;
        currentLv = levelData[currentLvInt];

        levelHolder.SetSceneName(currentLv);

        if(hasTransition) //if the scene has a curtain transition
        { 
            transitionSetter.SetTrigger();
            await Awaitable.WaitForSecondsAsync(transitionWaitTime);
        }
        
        sceneSwitching.LoadScene();
    }

    public async void HomeLevel(LevelData lv)
    {
        levelHolder.SetSceneName(lv);

        if (hasTransition)
        {
            transitionSetter.SetTrigger();
            await Awaitable.WaitForSecondsAsync(transitionWaitTime);
        }

        sceneSwitching.LoadScene();
    }

    public void SwitchDifficulty()
    {
        isHard = !isHard;
    }
}
