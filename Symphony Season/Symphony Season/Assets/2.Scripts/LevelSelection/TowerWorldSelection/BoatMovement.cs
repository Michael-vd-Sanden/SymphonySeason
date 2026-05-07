using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject oceanObject;
    [SerializeField] private int layersToHit;
    private Vector3 screenPos, worldPos, gridPos;
    private int layerAsLayerMask;

    public int allowedSpace; //amount of space before ocean starts moving;

    [SerializeField] private bool boatIsMoving;

    private void Awake()
    {
        layerAsLayerMask = (1 << layersToHit);
    }

    private void Update()
    {
        if(boatIsMoving) //check if boat has finished moving
        { 
            if(!playerData.isMoving) 
            { boatIsMoving = false; }
        }
    }

    private void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hitData, 100, layerAsLayerMask))
        {
            /*if(hitData.collider.CompareTag("Ocean"))
            {
                worldPos = hitData.point;
                playerData.destination = worldPos; // maybe not needed
                MoveBoat();
            }*/
            if (NavMesh.SamplePosition(hitData.point, out NavMeshHit navMeshHit, playerSettings.sampleDistance, NavMesh.AllAreas))
            {
                worldPos = navMeshHit.position + playerSettings.baseOffset;
               // gridPos = new Vector3(Mathf.FloorToInt(worldPos.x), Mathf.FloorToInt(worldPos.y), Mathf.FloorToInt(worldPos.z));
                //Debug.Log(gridPos);
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

                Vector3 pos = playerData.destination;
                //check if distance is far enough away to rotate ocean towords camera;
                if ((pos.x > 1f || pos.x < -1f)|| (pos.z > 1f || pos.z < -1f))
                {
                    //mirror position
                    // Vector3 temp = new Vector3(playerData.destination.x *-1, playerData.destination.y *-1, playerData.destination.z * -1);
                    Vector3 temp = playerData.destination * -1;
                    oceanObject.transform.LookAt(temp);
                }

                break;
            default:
                //Debug.Log("Can't move there");
                break;
        }
    }

    private void Move(InputAction.CallbackContext obj)
    {
        screenPos = obj.ReadValue<Vector2>();
        if(!boatIsMoving) { CastRay(); }
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
