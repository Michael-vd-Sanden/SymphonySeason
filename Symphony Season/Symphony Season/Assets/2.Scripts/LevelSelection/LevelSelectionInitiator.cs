using System.Threading.Tasks;
using UnityEngine;

public class LevelSelectionInitiator : MonoBehaviour
{
    [Header("-------------- Classes")]
    [SerializeField] private LevelIndex levelIndex;

    [Header("-------------- Scriptable Objects")]
    [SerializeField] private LevelHolder levelHolder;

    private async void Start()
    {
        await InitializeClasses();
        await CreateObjects();
        await PrepareLevel();

        levelHolder.newSceneHasLoaded = true;
    }

    private async Task InitializeClasses() //every start and awake function that has to do with setting things
    {
        levelIndex.DioramaAnimators[levelIndex.FloorIndex].SetTrigger("Pulsing");
        levelIndex.isRunning = false;

        await Task.Yield();
    }

    private async Task CreateObjects() //making the big objects, loading extra scenes
    {
        await Task.Yield();
    }

    private async Task PrepareLevel() //every start and awake function that has to do with posistioning and appearance
    {
        //await Awaitable.WaitForSecondsAsync(1f);
        await Task.Yield();
    }
}
