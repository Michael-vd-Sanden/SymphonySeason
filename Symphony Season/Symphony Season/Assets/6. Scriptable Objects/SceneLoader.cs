using UnityEngine;

[CreateAssetMenu(fileName = "SceneLoader", menuName = "Scriptable Objects/SceneLoader")]
public class SceneLoader : ScriptableObject
{
    public string SceneToLoad;
    public bool SceneHasLoaded;   
}
