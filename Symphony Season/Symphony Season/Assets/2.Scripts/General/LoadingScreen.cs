using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private LevelHolder levelHolder;

    private void Start()
    {
        SceneManager.LoadSceneAsync(levelHolder.sceneNameToLoad);
    }

    private void Update()
    {
        if(levelHolder.newSceneHasLoaded) 
        {
            levelHolder.newSceneHasLoaded = false;
            SceneManager.UnloadSceneAsync("LoadingScene");
        }
    }
}
