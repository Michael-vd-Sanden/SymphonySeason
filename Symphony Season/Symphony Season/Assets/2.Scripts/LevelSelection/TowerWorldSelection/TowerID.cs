using UnityEngine;

public class TowerID : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    public LevelData levelData;
    public GameObject popUpLevel;
    public GameObject popUpLock;
    public TowerSelectionManager towerSelection;

    [Header("-------------- Changeble Values")]
    public bool hasLevels;

    private void OnTriggerEnter(Collider other) //if the player comes inside the trigger collider
    {
        if (other.CompareTag("Player"))
        {
            towerSelection.currentTower = this;
            if(hasLevels) popUpLevel.SetActive(true);
            else popUpLock.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) //if the player exits the trigger collider
    {
        towerSelection.currentTower = null;
        if (hasLevels) popUpLevel.SetActive(false);
        else popUpLock.SetActive(false);
    }
    public void ClickedOnLevel()
    {
        Debug.Log("click");
        towerSelection.ChangeLevel();
    }
}
