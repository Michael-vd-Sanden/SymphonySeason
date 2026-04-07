using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BPGameInitiator : MonoBehaviour
{
    [Header("-------------- Classes")]
    [SerializeField] private Camera orthographicCamera;
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private Canvas holdBtnsCanvas;
    public PlayerUIDirections playerUIDirections; 
    public PlayerMovement player;       //public for victoryTrigger
    public MoveObject victoryMover;
    [SerializeField] private PlayerFollower playerSprites;
    [SerializeField] private BlockPuzzleManager blockPuzzleManager;
    [SerializeField] private AudioPlayer audioPlayer;
    [SerializeField] private VictoryTrigger victoryTrigger;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private TriggerSetter curtainTransition;

    [Header("-------------- Objects")]
    [SerializeField] private string environmentSceneName;
    [SerializeField] private GameObject notepipes;
    [SerializeField] private GameObject globalRoot;

    private PopupRotator[] popupRotators;
    private MoveBlockScript[] moveBlocks;

    [Header("-------------- Scriptable Objects")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private SceneLoader sceneLoader;
    

    private async void Start()
    {
        //loadingScreen = Instantiate(loadingScreen);
        //orthographicCamera = Instantiate(orthographicCamera);
        //loadingScreen.Show();

        BindObjects();
        await InitializeClasses();
        await CreateObjects();
        await PrepareLevel();

        sceneLoader.SceneHasLoaded = true;
        curtainTransition.SetTrigger();
    }

    private void BindObjects()  //making the classes
    {
        /*
        mainCanvas= Instantiate(mainCanvas);
        holdBtnsCanvas= Instantiate(holdBtnsCanvas);
        player = Instantiate(player);
        playerSprites = Instantiate(playerSprites);
        blockPuzzleManager= Instantiate(blockPuzzleManager);
        audioPlayer= Instantiate(audioPlayer);
        victoryTrigger= Instantiate(victoryTrigger);
        playerData = Instantiate(playerData);*/
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
       // notepipes = Instantiate(notepipes);
        //globalRoot = Instantiate(globalRoot);
        await Task.Yield();
    }

    private async Task PrepareLevel()   //every start and awake function that has to do with posistioning and appearance
    {
        popupRotators = FindObjectsByType<PopupRotator>(FindObjectsSortMode.None);
        foreach (PopupRotator r in popupRotators) { r.SetRotator(); }

        //replace when fixing change colours
        moveBlocks = FindObjectsByType<MoveBlockScript>(FindObjectsSortMode.None);
        foreach (MoveBlockScript m in moveBlocks) { m.ChangeColourBasedOnNote(); }

        playerUIDirections.CheckPlayerDirections();

        await Awaitable.WaitForSecondsAsync(1f);        //This is always better than Task.Delay()
        Debug.Log("waited");
    }

}
