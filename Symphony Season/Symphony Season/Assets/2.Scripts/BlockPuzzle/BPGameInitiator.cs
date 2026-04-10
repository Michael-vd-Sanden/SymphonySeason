using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BPGameInitiator : MonoBehaviour
{
    [Header("-------------- Classes")]
    [SerializeField] PlayerUIDirections playerUIDirections; 
    [SerializeField] PlayerMovement player;
    [SerializeField] private PlayerFollower playerSprites;
    [SerializeField] private BlockPuzzleManager blockPuzzleManager;
    [SerializeField] private TriggerSetter curtainTransition;

    [Header("-------------- Objects")]
    [SerializeField] private string environmentSceneName;

    private PopupRotator[] popupRotators;
    private MoveBlockScript[] moveBlocks;

    [Header("-------------- Scriptable Objects")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private LevelHolder sceneLoader;
    

    private async void Start()
    {
        await InitializeClasses();
        await CreateObjects();
        await PrepareLevel();

        sceneLoader.newSceneHasLoaded = true;
        curtainTransition.SetTrigger();
    }

    private async Task InitializeClasses()  //every start and awake function that has to do with setting things
    {
        player.agent.speed = playerSettings.moveSpeed;

        playerUIDirections.layerAsLayerMask = (1 << playerUIDirections.layer);
        

        blockPuzzleManager.layerAsLayerMask = (1 << blockPuzzleManager.hitLayer);

        playerSprites.ToggleLeft(0f);
        playerSprites.ToggleMoving(0f);
        playerSprites.ToggleHolding(0f);

        await Task.Yield();
    }

    private async Task CreateObjects()  //making the big objects
    { //returns the task automatically, don't have to return it manually
        SceneManager.LoadScene(environmentSceneName, LoadSceneMode.Additive);
        await Task.Yield();
    }

    private async Task PrepareLevel()   //every start and awake function that has to do with posistioning and appearance
    {
        popupRotators = FindObjectsByType<PopupRotator>(FindObjectsSortMode.None);
        foreach (PopupRotator r in popupRotators) { r.SetRotator(); }

        //replace when fixing change colours
        moveBlocks = FindObjectsByType<MoveBlockScript>(FindObjectsSortMode.None);
        foreach (MoveBlockScript m in moveBlocks) { m.ChangeColourBasedOnNote(); }

        await Awaitable.FixedUpdateAsync();
        playerUIDirections.CheckPlayerDirections();

        //await Awaitable.WaitForSecondsAsync(1f);        //This is always better than Task.Delay()
        await Task.Yield();
    }
}
