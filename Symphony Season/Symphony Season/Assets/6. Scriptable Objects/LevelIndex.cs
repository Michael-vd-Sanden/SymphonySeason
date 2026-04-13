using UnityEngine;

[CreateAssetMenu(fileName = "LevelIndex", menuName = "Scriptable Objects/LevelIndex")]
public class LevelIndex : ScriptableObject
{
    public string sceneName;        //The name of the level selection scene this SO is on

    public int floorIndex = 0;
    public int floorMaximum = 3;
}
