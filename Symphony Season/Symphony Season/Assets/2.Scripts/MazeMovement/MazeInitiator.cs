using System.Threading.Tasks;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeInitiator : MonoBehaviour
{
    [Header("-------------- Classes")]
    [SerializeField] private PlayerMovement player;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerFollower playerSprites;
    [SerializeField] private MazeMovement mazeMovement;

    [Header("-------------- Scriptable Objects")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private LevelHolder levelHolder;

    private async void Start()
    {
        BindObjects();
        await InitializeClasses();
        await CreateObjects();
        await PrepareLevel();

        levelHolder.newSceneHasLoaded = true;
    }

    private void BindObjects()  //making the classes
    {
        
    }

    private async Task InitializeClasses()  //every start and awake function that has to do with setting things
    {
        player.agent.speed = playerSettings.moveSpeed;
        
        playerData.isInMaze = true;
        playerData.allowedToMove= true;

        mazeMovement.currentAngleID = 0;
        mazeMovement.layerAsLayerMask = (1 << mazeMovement.layer);

        playerSprites.ToggleLeft(0f);
        playerSprites.ToggleMoving(0f);
        playerSprites.ToggleHolding(0f);

        await Task.Yield();
    }

    private async Task CreateObjects()  //making the big objects
    { //returns the task automatically, don't have to return it manually
      //SceneManager.LoadScene(environmentSceneName, LoadSceneMode.Additive);
        SceneManager.LoadScene(levelHolder.sceneNameToLoadExtra, LoadSceneMode.Additive);

        await Task.Yield();
    }

    private async Task PrepareLevel()   //every start and awake function that has to do with posistioning and appearance
    {
        mazeMovement.mazeObject = GameObject.FindGameObjectWithTag("MazeObject");
        mazeMovement.navMesh = GameObject.FindGameObjectWithTag("NavMesh").GetComponent<NavMeshSurface>();

        mazeMovement.navMesh.BuildNavMesh();
        await Awaitable.FixedUpdateAsync();
        mazeMovement.CheckPlayerDirections();

        await Awaitable.WaitForSecondsAsync(1f);        //This is always better than Task.Delay()
        Debug.Log("waited");
    }
}
