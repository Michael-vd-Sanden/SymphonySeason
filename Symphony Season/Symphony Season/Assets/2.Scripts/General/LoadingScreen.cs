using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private SceneLoader loader;

    private void Start()
    {
        SceneManager.LoadSceneAsync(loader.SceneToLoad);
    }

    private void Update()
    {
        if(loader.SceneHasLoaded) 
        {
            loader.SceneHasLoaded = false;
            SceneManager.UnloadSceneAsync("LoadingScene");
        }
    }
}
