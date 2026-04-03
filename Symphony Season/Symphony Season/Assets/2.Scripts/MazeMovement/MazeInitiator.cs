using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeInitiator : MonoBehaviour
{
    [Header("-------------- Classes")]
    //[SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject eventSystem;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerFollower playerSprites;
    [SerializeField] private MazeMovement mazeMovement;

    [Header("-------------- Objects")]
    [SerializeField] private string environmentSceneName;
    [SerializeField] private string loadingSceneName;
    [SerializeField] private GameObject mazeObject;
    [SerializeField] private GameObject visualEffects;
    [SerializeField] private GameObject navmesh;
    [SerializeField] private Canvas questionCanvas;
    [SerializeField] private GameObject globalRoot;

    [Header("-------------- Scriptable Objects")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private SceneLoader sceneLoader;

    private async void Start()
    {
        BindObjects();
        await InitializeClasses();
        await CreateObjects();
        await PrepareLevel();

        sceneLoader.SceneHasLoaded = true;
    }

    private void BindObjects()  //making the classes
    {
        eventSystem = Instantiate(eventSystem);
        // player = Instantiate(player);
        //player = player.Initiate();
        //audioPlayer = Instantiate(audioPlayer);
        //playerData = playerData.Initiate();
        //playerData = Instantiate(playerData);
         //mazeMovement = mazeMovement.Initiate();
        //mazeMovement = Instantiate(mazeMovement);
    }

    private async Task InitializeClasses()  //every start and awake function that has to do with setting things
    {
        player.agent.speed = playerSettings.moveSpeed;
        
        playerData.isInMaze = true;

        mazeMovement.currentAngleID = 0;
        mazeMovement.layerAsLayerMask = (1 << mazeMovement.layer);
        await Task.Yield();
    }

    private async Task CreateObjects()  //making the big objects
    { //returns the task automatically, don't have to return it manually
      //SceneManager.LoadScene(environmentSceneName, LoadSceneMode.Additive);
        playerSprites = Instantiate(playerSprites); //camera is child of playersprites
        mazeObject = Instantiate(mazeObject);
        visualEffects = Instantiate(visualEffects);
        navmesh = Instantiate(navmesh);
        questionCanvas = Instantiate(questionCanvas);
        globalRoot = Instantiate(globalRoot);
        await Task.Yield();
    }

    private async Task PrepareLevel()   //every start and awake function that has to do with posistioning and appearance
    {
        player.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
        mazeObject.transform.position = new Vector3(18f, 11f, 0f);

        await Awaitable.FixedUpdateAsync();
        mazeMovement.CheckPlayerDirections();

        await Awaitable.WaitForSecondsAsync(1f);        //This is always better than Task.Delay()
        Debug.Log("waited");
    }
}
