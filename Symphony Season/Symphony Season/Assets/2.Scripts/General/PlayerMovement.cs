using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMovement thisPlayerMovement;
    [Header("-------------- Required Objects")]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerSettings playerSettings;
    public NavMeshAgent agent;  
    
    public PlayerMovement Initiate()
    {
        return thisPlayerMovement = Instantiate(this);
    }

    private void Update()
    {
        if(playerData.isMoving) 
        {
            if(playerData.isInMaze) { playerData.allowedToMove= false; }
            playerData.currentPos = transform.position;
            if ((playerData.currentPos.x - playerSettings.targetMargin.x < playerData.destination.x && playerData.currentPos.x + playerSettings.targetMargin.x > playerData.destination.x)
                && (playerData.currentPos.z - playerSettings.targetMargin.z < playerData.destination.z && playerData.currentPos.z + playerSettings.targetMargin.z > playerData.destination.z))
            { //Checks if close enough to destination
                //sets postition to destination
                transform.position = new Vector3(playerData.destination.x, playerData.currentPos.y, playerData.destination.z);
                playerData.currentPos = transform.position;

                if(playerData.isInMaze) { playerData.allowedToMove = true; }
                if (!playerData.isMouseMovement && !playerData.isInMaze) { playerData.stoppedMoving = true;}
                playerData.isMoving = false;
            }
        }
    }

    public void CheckIfCanReachDestination()
    {
        var path = new NavMeshPath();
        agent.CalculatePath(playerData.destination, path);
        switch (path.status)
        {
            case NavMeshPathStatus.PathComplete:
                playerData.isMoving = true;
                agent.SetDestination(playerData.destination);
                playerData.currentPos = transform.position;
                
                if(playerData.destination.x < playerData.currentPos.x || playerData.destination.z > playerData.currentPos.z)
                { playerData.isMovingLeft = true; }
                else { playerData.isMovingLeft = false; }
                break;
            default:
                //Debug.Log("Can't move there");
                break;
        }
    }

    public void MoveOutsideScript(Vector3 pos) 
    {
        if (!playerData.isMoving)
        {
            playerData.destination = pos;
            CheckIfCanReachDestination();
        }
    }
}
