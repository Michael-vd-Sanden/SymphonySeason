using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeInitiator : MonoBehaviour
{
    [SerializeField] private LoadingScreen loadingScreen;
    [Header("-------------- Classes")]
    //[SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject eventSystem;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerFollower playerSprites;
    [SerializeField] private MazeMovement mazeMovement;

    [Header("-------------- Objects")]
    [SerializeField] private string environmentSceneName;
    [SerializeField] private GameObject mazeObject;
    [SerializeField] private GameObject visualEffects;
    [SerializeField] private GameObject navmesh;
    [SerializeField] private Canvas questionCanvas;
    [SerializeField] private GameObject globalRoot;

    [Header("-------------- Scriptable Objects")]
    [SerializeField] private PlayerSettings playerSettings;

    private async void Start()
    {
        loadingScreen = Instantiate(loadingScreen);
        playerSprites = Instantiate(playerSprites); //camera is child of playersprites
        loadingScreen.Show();

        BindObjects();
        await InitializeClasses();
        await CreateObjects();
        await PrepareLevel();
        loadingScreen.Hide();
    }

    private void BindObjects()  //making the classes
    {
        eventSystem = Instantiate(eventSystem);
        player = Instantiate(player);
        //audioPlayer = Instantiate(audioPlayer);
        playerData = Instantiate(playerData);
        mazeMovement = Instantiate(mazeMovement);
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
        mazeObject = Instantiate(mazeObject);
        visualEffects = Instantiate(visualEffects);
        navmesh = Instantiate(navmesh);
        questionCanvas = Instantiate(questionCanvas);
        globalRoot = Instantiate(globalRoot);
        await Task.Yield();
    }

    private async Task PrepareLevel()   //every start and awake function that has to do with posistioning and appearance
    {
        player.gameObject.transform.localScale *= 2;
        mazeObject.transform.position = new Vector3(18f, 11f, 0f);

        await Awaitable.FixedUpdateAsync();
        mazeMovement.CheckPlayerDirections();

        await Awaitable.WaitForSecondsAsync(1f);        //This is always better than Task.Delay()
        Debug.Log("waited");
    }
}
