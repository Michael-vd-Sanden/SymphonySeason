using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class UnnamedInitiator : MonoBehaviour
{
    [Header("-------------- Classes")]
    [SerializeField] private TriggerSetter curtainTransition;
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PlayerSettings playerSettings;

    [Header("-------------- Scriptable Objects")]
    [SerializeField] private LevelHolder levelHolder;

   // [Header("-------------- Objects (do not assign)")]

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

        agent.speed = playerSettings.moveSpeed;
        await Task.Yield();
    }

    private async Task CreateObjects() //making the big objects, loading extra scenes
    {
        await Task.Yield();
    }

    private async Task PrepareLevel() //every start and awake function that has to do with posistioning and appearance
    {


        await Awaitable.WaitForSecondsAsync(1f);
        await Task.Yield();
    }
}
