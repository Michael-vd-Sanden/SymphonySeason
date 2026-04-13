using System.Threading.Tasks;
using UnityEngine;

public class LevelSelectionInitiator : MonoBehaviour
{
    [Header("-------------- Classes")]
    [SerializeField] private LevelIndex levelIndex;
    [SerializeField] private LvUIController lvUIController;
    [SerializeField] private TriggerSetter curtainTransition;
    [SerializeField] private TextureChanger textureChanger;
    [SerializeField] private MoveObject cameraMover;

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
        lvUIController.dioramaAnimators[levelIndex.floorIndex].SetTrigger("Pulsing");
        lvUIController.isRunning = false;

        curtainTransition.SetTrigger();

        textureChanger.NextTexture(textureChanger.FrontMat, textureChanger.LevelScreenshotsFront[levelIndex.floorIndex]);

        await Task.Yield();
    }

    private async Task CreateObjects() //making the big objects, loading extra scenes
    {
        await Task.Yield();
    }

    private async Task PrepareLevel() //every start and awake function that has to do with posistioning and appearance
    {
        cameraMover.MoveTo(levelIndex.floorIndex);

        await Awaitable.WaitForSecondsAsync(3f); // to give cameraMover some time
        await Task.Yield();
    }
}
