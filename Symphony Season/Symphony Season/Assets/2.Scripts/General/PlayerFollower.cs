using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private Material playerMaterial;

    [Header("-------------- Background Values (do not change)")]
    private bool hasToggledMoving = false;
    private bool hasToggledHolding = false;

    void Update()
    {
        if(playerSettings.isMoving) 
        {
            SetPositionToPlayer();
            if (!hasToggledMoving) { ToggleMoving(1f); }
            hasToggledMoving = true;

            if (playerSettings.isMovingLeft) { ToggleLeft(1f); }
            else if (!playerSettings.isMovingLeft) { ToggleLeft(0f); }
        }
        else if(!playerSettings.isMoving) 
        {
            if (hasToggledMoving) { ToggleMoving(0f); }
            hasToggledMoving = false;
        }

        if(playerSettings.isHoldingSomething && !hasToggledHolding)
        {
            ToggleHolding(1f);
            hasToggledHolding = true;
        }
        else if (!playerSettings.isHoldingSomething && hasToggledHolding)
        {
            ToggleHolding(0f);
            hasToggledHolding = false;
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
