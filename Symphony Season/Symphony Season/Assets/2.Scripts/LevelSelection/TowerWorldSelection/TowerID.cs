using UnityEngine;

public class TowerID : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    public LevelData levelData;
    public GameObject popUp;
    public TowerSelectionManager towerSelection;

    private void OnTriggerEnter(Collider other) //if the player comes inside the trigger collider
    {
        if (other.CompareTag("Player"))
        {
            towerSelection.currentTower = this;
            popUp.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) //if the player exits the trigger collider
    {
        towerSelection.currentTower = null;
        popUp.SetActive(false);
    }
    public void ClickedOnLevel()
    {
        Debug.Log("click");
        towerSelection.ChangeLevel();
    }
}
