using UnityEngine;

[CreateAssetMenu(fileName = "LevelIndex", menuName = "Scriptable Objects/LevelIndex")]
public class LevelIndex : ScriptableObject
{//placed on tower level selection object
    public string sceneName;        //The name of the level selection scene this SO is on

    //how many floors are in this tower, and what level it is on currently
    public int floorIndex = 0;      
    public int floorMaximum = 3;
}
