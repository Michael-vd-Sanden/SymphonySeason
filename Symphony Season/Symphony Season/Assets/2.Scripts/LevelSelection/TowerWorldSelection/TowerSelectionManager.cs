using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class TowerSelectionManager : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private LevelHolder levelHolder;
    [SerializeField] private SceneSwitching sceneSwitching;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private TriggerSetter curtainTransition;

    [Header("-------------- Changeble Values")]
    [SerializeField] private bool hasTransition;
    [SerializeField] private float transitionWaitTime;

    [Header("-------------- Background Values (do not change)")]
    public LevelData currentLv;
    public TowerID currentTower;


    public async void ChangeLevel() //called on play level btn
    {
        playerData.allowedToMove = false;
        currentLv = currentTower.levelData;

        levelHolder.SetSceneName(currentLv);

        if(hasTransition) 
        {
            curtainTransition.SetTrigger();
            await Awaitable.WaitForSecondsAsync(transitionWaitTime);
        }

        sceneSwitching.LoadScene();
    }
}
