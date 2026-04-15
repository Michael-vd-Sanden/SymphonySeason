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
    [SerializeField] private ColourChanger blockColourChanger;
    [SerializeField] private NoteSetter noteSetter;
    [SerializeField] private PlayerData playerData;

    [Header("-------------- Objects")]
    [SerializeField] private string environmentSceneName;

    private PopupRotator[] popupRotators;
    private MoveBlockScript[] moveBlocks;
    [SerializeField] private GameObject[] noteObjects;

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
        playerData.allowedToMove = true;

        playerUIDirections.layerAsLayerMask = (1 << playerUIDirections.layer);
        

        blockPuzzleManager.layerAsLayerMask = (1 << blockPuzzleManager.hitLayer);

        playerSprites.ToggleLeft(0f);
        playerSprites.ToggleMoving(0f);
        playerSprites.ToggleHolding(0f);

        moveBlocks = FindObjectsByType<MoveBlockScript>(FindObjectsSortMode.None);
        foreach (MoveBlockScript m in moveBlocks) 
        {
            m.playerMovement = player;
            m.manager = blockPuzzleManager;
            m.colourChanger = blockColourChanger;
            noteSetter.CheckNoteIndex(m.blockNote);
        }
        foreach (int n in noteSetter.noteIndexes) 
        { noteObjects[n].SetActive(true); }

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

        foreach (MoveBlockScript m in moveBlocks) { ChangeColourBasedOnNote(m); }

        await Awaitable.FixedUpdateAsync();
        playerUIDirections.CheckPlayerDirections();

        //await Awaitable.WaitForSecondsAsync(1f);        //This is always better than Task.Delay()
        await Task.Yield();
    }


    public void ChangeColourBasedOnNote(MoveBlockScript b)       //move
    {
        b.colourMaterial = b.colourChanger.ChangeColourBasedOnNote(b.blockNote);

        var materialTemp = b.colourBlockRenderer.materials;
        materialTemp[b.materialInArray] = b.colourMaterial;
        b.colourBlockRenderer.materials = materialTemp;

        var material2Temp = b.colourQuestionRenderer.materials;
        //material2Temp[0].EnableKeyword("_EMISSION");
        //material2Temp[0].color = colourMaterial.GetColor("_EmissionColor");
        material2Temp[0] = b.colourMaterial;
        b.colourQuestionRenderer.materials = material2Temp;

        var material3Temp = b.colourNoteRenderer.materials;
        // material3Temp[0].EnableKeyword("_EMISSION");
        //material3Temp[0].color = colourMaterial.GetColor("_EmissionColor");
        material3Temp[0] = b.colourMaterial;
        b.colourNoteRenderer.materials = material3Temp;
    }
}
