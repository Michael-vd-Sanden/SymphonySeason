using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    //This class is added to each tower level selection
    [SerializeField] private LevelIndex levelIndex;     //Might be replaced in future
    [SerializeField] private LevelHolder levelHolder;
    [SerializeField] private SceneSwitching sceneSwitching;
    
    [Header("-------------- Changeble Values")]
    public LevelData[] levelData;
    //level container is structured as (easy lv, hard lv, easy lv, hard lv...)
    //so easy levels are on the even (start at 0) and hard levels are uneven

    [Header("-------------- Background Values (do not change)")]
    public LevelData currentLv;
    public bool isHard = false;   //changed while turning level
    private int currentLvInt;        //changed while selecting level (now through levelindex)

    public void ChangeLevel()       //called on play level btn
    {
        int difficultyAdditive = 0;         // depending on easy or hard
        int difficultyMultiplier = 2;       // always
        if (isHard)
        { difficultyAdditive = 1; }

        currentLvInt = (levelIndex.FloorIndex * difficultyMultiplier) + difficultyAdditive;
        currentLv = levelData[currentLvInt];

        levelHolder.SetSceneName(currentLv);
        sceneSwitching.LoadScene();
    }

    public void SwitchDifficulty()
    {
        isHard = !isHard;
    }
}
