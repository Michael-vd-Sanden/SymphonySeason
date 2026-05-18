using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class BoatMovement : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private NavMeshAgent agent;   

    [Header("-------------- Changeble Values")]
    public int layersToHit;

    [Header("-------------- Background Values (do not change)")]
    [SerializeField] private bool boatIsMoving;
    private Vector3 screenPos, worldPos;
    public int layerAsLayerMask;

    private void Update()
    {
        if (boatIsMoving) //check if boat has finished moving
        {
            Vector3 t = transform.position;
            Vector3 d = playerData.destination;
            Vector3 p = playerSettings.targetMargin;

            if ((t.x - p.x < d.x && t.x + p.x > d.x)
                && (t.z - p.z < d.z && t.z + p.z > d.z)
                && (t.y - p.y < d.y && t.y + p.y > d.y))
            { //Checks if close enough to destination
                //sets destination to postition
                playerData.destination = transform.position;
                agent.destination = transform.position;

                playerData.isMoving = false;
                boatIsMoving = false;
            }   
        }
    }

    private void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hitData, 100, layerAsLayerMask))
        {
            if (NavMesh.SamplePosition(hitData.point, out NavMeshHit navMeshHit, playerSettings.sampleDistance, NavMesh.AllAreas)) 
            {//clicked on a point on the navmesh where the player can move to
                worldPos = navMeshHit.position + playerSettings.baseOffset;
                playerData.destination = worldPos;

                CheckIfCanReachDestination();
            }
        }
    }

    public void CheckIfCanReachDestination()
    {
        var path = new NavMeshPath();
        agent.CalculatePath(playerData.destination, path);
        switch (path.status)
        {
            case NavMeshPathStatus.PathComplete: //can make path
                playerData.isMoving = true;
                boatIsMoving = true;
                agent.SetDestination(playerData.destination);
                playerData.currentPos = transform.position;
                break;
            default:
                //Debug.Log("Can't move there");
                break;
        }
    }

    //screen input
    private void Move(InputAction.CallbackContext obj)
    {
        screenPos = obj.ReadValue<Vector2>();
        if (playerData.allowedToMove) { CastRay(); }
    }

    private void OnEnable()
    {
        moveAction.action.performed += Move;
    }

    private void OnDisable()
    {
        moveAction.action.performed -= Move;
    }
}
