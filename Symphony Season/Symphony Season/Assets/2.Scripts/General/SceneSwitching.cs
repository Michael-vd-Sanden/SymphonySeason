using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    public LevelHolder sceneLoader;

    [Header("-------------- Changeble Values")]
    public string nextScene;


    public void ChangeSceneName (string name)
    {
        sceneLoader.sceneNameToLoad = name;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void NextScene()
    {
        sceneLoader.sceneNameToLoad = nextScene;
        LoadScene();
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
