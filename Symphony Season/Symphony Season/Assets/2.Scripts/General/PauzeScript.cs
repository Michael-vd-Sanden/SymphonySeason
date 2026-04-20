using UnityEngine;

public class PauzeScript : MonoBehaviour
{
    [SerializeField] private SceneSwitching sceneSwitch;
    [SerializeField] private TriggerSetter curtainTriggers;
    [SerializeField] private LevelIndex levelIndex;

    public void Pauze()
    {
        curtainTriggers.SetTrigger();
        //Time.timeScale = 0f;
    }

    public void UnPauze()
    {
        //Time.timeScale = 1.0f;
        curtainTriggers.SetTrigger();
    }

    public void MainMenu()
    {
        UnPauze();
        sceneSwitch.ChangeSceneName(levelIndex.sceneName);
        sceneSwitch.LoadScene();
    }
}
