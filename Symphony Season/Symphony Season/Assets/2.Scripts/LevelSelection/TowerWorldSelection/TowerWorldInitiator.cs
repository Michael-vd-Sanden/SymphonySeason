using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TowerWorldInitiator : MonoBehaviour
{
    [Header("-------------- Classes")]
    [SerializeField] private TriggerSetter curtainTransition;
    [SerializeField] private TowerSelectionManager towerSelection;
    [SerializeField] private Camera cam;

    [Header("-------------- Scriptable Objects")]
    [SerializeField] private LevelHolder levelHolder;

    [Header("-------------- Objects (do not assign)")]
    [SerializeField] private TowerID[] towers;
    [SerializeField] private List<Canvas> towerCanvases;
    [SerializeField] private List<FollowObject> followObjects;

    private async void Start()
    {
        await InitializeClasses();
        await CreateObjects();
        await PrepareLevel();

        levelHolder.newSceneHasLoaded = true;
    }

    private async Task InitializeClasses() //every start and awake function that has to do with setting things
    {
        towers = FindObjectsByType<TowerID>(FindObjectsSortMode.None);
        foreach (TowerID t in towers) 
        { 
            t.towerSelection = towerSelection; 
            towerCanvases.Add(t.GetComponentInChildren<Canvas>());
            followObjects.Add(t.GetComponentInChildren<FollowObject>());
        }
        foreach (Canvas c in towerCanvases) { c.worldCamera = cam; }
        foreach (FollowObject f in followObjects) { f.lookAtObject = cam.gameObject; }
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
