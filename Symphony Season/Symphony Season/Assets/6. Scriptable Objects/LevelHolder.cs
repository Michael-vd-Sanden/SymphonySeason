using UnityEngine;

[CreateAssetMenu(fileName = "LevelHolder", menuName = "Scriptable Objects/LevelHolder")]
public class LevelHolder : ScriptableObject
{
    public string sceneNameToLoad;
    public string sceneNameToLoadExtra;     //will be loaded by the original scene, for if the puzzle environment contains the puzzle elements
    public bool newSceneHasLoaded;

    //level containers are structured as (easy lv, hard lv, easy lv, hard lv...)
    //so easy levels are on the even (start at 0) and hard levels are uneven
    //add new level containers for every new LevelType you add
    public string[] levelSelectionLevels;
    public string[] blockPuzzleLevels;
    public string[] mazeLevels;

    public void SetSceneName(LevelData level) 
    {
        int difficultyAdditive = 0;         // depending on easy or hard
        int difficultyMultiplier = 2;       // always
        if (level.difficulty == Difficulty.Hard)
        { difficultyAdditive = 1; }

        int i = (level.levelID * difficultyMultiplier) + difficultyAdditive;
        switch (level.levelType)
        {
            case LevelType.LevelSelection:  
                sceneNameToLoad = levelSelectionLevels[level.levelID]; //no difficulties
                break;
            case LevelType.BlockPuzzle:
                sceneNameToLoad = blockPuzzleLevels[i];
                break;
            case LevelType.Maze:    
                sceneNameToLoad = "MazeGameplay";
                sceneNameToLoadExtra = mazeLevels[level.levelID]; //no difficulties
                break;
            default:
                Debug.Log("No such Scene exists");
                break;
        }
    }
}
