using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public int levelID;             //exmp: lv.0 easy & lv.0 hard are both lvID 0
    public LevelType levelType;
    public Difficulty difficulty; 
    public bool completed;
    public float completionTime;

    public void SetcompletionTime(float newTime)
    {
        if(!completed) { completed = true; completionTime = newTime; }
        if(newTime < completionTime) completionTime = newTime;
    }
}
