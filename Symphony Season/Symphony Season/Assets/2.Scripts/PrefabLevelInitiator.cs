using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PrefabLevelInitiator : MonoBehaviour
{
    [Header("-------------- Classes")]
    [SerializeField] private TriggerSetter curtainTransition;
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerFollower playerSprites;

    [Header("-------------- Objects")]
    [SerializeField] private string environmentSceneName;

    [Header("-------------- Scriptable Objects")]
    [SerializeField] private LevelHolder levelHolder;

    private async void Start()
    {
        await InitializeClasses();
        await CreateObjects();
        await PrepareLevel();

        levelHolder.newSceneHasLoaded = true;
        curtainTransition.SetTrigger();
    }

    private async Task InitializeClasses() //every start and awake function that has to do with setting things
    {
        //reset player sprite
        playerSprites.ToggleLeft(0f);
        playerSprites.ToggleMoving(0f);
        playerSprites.ToggleHolding(0f);

        agent.speed = playerSettings.moveSpeed;
        await Task.Yield();
    }

    private async Task CreateObjects() //making the big objects, loading extra scenes
    {
        if(environmentSceneName != string.Empty && environmentSceneName != null) 
            SceneManager.LoadScene(environmentSceneName, LoadSceneMode.Additive);
        await Task.Yield();
    }

    private async Task PrepareLevel() //every start and awake function that has to do with posistioning and appearance
    {


        await Awaitable.WaitForSecondsAsync(1f);
        await Task.Yield();
    }
}
