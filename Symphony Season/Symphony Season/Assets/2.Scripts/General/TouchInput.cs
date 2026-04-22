using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] public InputActionReference moveAction;
    [SerializeField] private Vector2[] UIMask;
    [SerializeField] private int layersToHit;
    private Vector3 screenPos, worldPos, gridPos;
    private int layerAsLayerMask;

    private void Awake()
    {
        layerAsLayerMask = (1 << layersToHit);
    }

    private void castRay()          
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
       /* if (playerData.canBeOverUI)
        {
            foreach (Vector2 pos in UIMask)
            {
                if (screenPos.x >= pos.x && screenPos.y <= pos.y)
                { //inside UIMask
                  // Debug.Log("in UIMask");
                    return;
                }
            }
        }*/

        if (Physics.Raycast(ray, out RaycastHit hitData, 100, layerAsLayerMask))
        {
            if (NavMesh.SamplePosition(hitData.point, out NavMeshHit navMeshHit, playerSettings.sampleDistance, NavMesh.AllAreas))
            {
                worldPos = navMeshHit.position + playerSettings.baseOffset;
                gridPos = new Vector3(Mathf.FloorToInt(worldPos.x), Mathf.FloorToInt(worldPos.y), Mathf.FloorToInt(worldPos.z));
                //Debug.Log(gridPos);
                playerData.destination = gridPos;

                playerMovement.CheckIfCanReachDestination();
            }
            else
            {
                //Debug.Log("not on navmesh");
                if (hitData.collider.CompareTag("Movable"))
                {
                    //Debug.Log("hit block");
                    //ga naar closest point van block
                }
            }
        }
    }
    private void OnEnable()          
    {
        moveAction.action.performed += Move;
    }

    private void OnDisable()      
    {
        moveAction.action.performed -= Move;
    }

    private void Move(InputAction.CallbackContext obj)   
    {
        screenPos = obj.ReadValue<Vector2>();
        if (playerData.allowedToMove && !playerData.isInMaze && playerData.isMouseMovement)
        {
            castRay();
        }
    }
}
