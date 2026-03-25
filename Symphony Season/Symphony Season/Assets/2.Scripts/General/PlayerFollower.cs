using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private Material playerMaterial;

    [Header("-------------- Background Values (do not change)")]
    private bool hasToggled = false;

    void Update()
    {
        if(playerSettings.isMoving) 
        {
            SetPositionToPlayer();
            if (!hasToggled) { ToggleMoving(1f); }
            hasToggled = true;

            if (playerSettings.isMovingLeft) { ToggleLeft(1f); }
            else if (!playerSettings.isMovingLeft) { ToggleLeft(0f); }
        }
        else if(!playerSettings.isMoving) 
        {
            if (hasToggled) { ToggleMoving(0f); }
            hasToggled = false;
        }
    }

    private void SetPositionToPlayer()
    {
        transform.position = new Vector3(playerSettings.currentPos.x + playerSettings.modelOffset.x, 
            playerSettings.currentPos.y + playerSettings.modelOffset.y, 
            playerSettings.currentPos.z + playerSettings.modelOffset.z);
    }

    public void ToggleLeft(float toggle)
    {
        playerMaterial.SetFloat("_IsLeft", toggle);
    }

    public void ToggleMoving(float toggle)
    {
        playerMaterial.SetFloat("_IsMoving", toggle);
    }

    public void ToggleHolding(float toggle)
    {
        playerMaterial.SetFloat("_IsHolding", toggle);
    }
}
