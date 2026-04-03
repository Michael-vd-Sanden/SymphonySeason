using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    public SceneLoader sceneLoader;

    [Header("-------------- Changeble Values")]
    public string nextScene;


    public void ChangeSceneName (string name)
    {
        sceneLoader.SceneToLoad = name;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void NextScene()
    {
        sceneLoader.SceneToLoad = nextScene;
        ChangeScene();
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
