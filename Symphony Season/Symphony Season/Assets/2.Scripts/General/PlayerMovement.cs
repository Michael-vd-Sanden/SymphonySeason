using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private PlayerSettings playerSettings; //Scriptable object
    public PlayerUIDirections playerUIDirections;
    public NavMeshAgent agent;  
    

    private void Update()
    {
        if(playerSettings.isMoving) 
        {
            if(playerSettings.isInMaze) { playerSettings.allowedToMove= false; }
            playerSettings.currentPos = transform.position;
            if ((playerSettings.currentPos.x - playerSettings.targetMargin.x < playerSettings.destination.x && playerSettings.currentPos.x + playerSettings.targetMargin.x > playerSettings.destination.x)
                && (playerSettings.currentPos.z - playerSettings.targetMargin.z < playerSettings.destination.z && playerSettings.currentPos.z + playerSettings.targetMargin.z > playerSettings.destination.z))
            { //Checks if close enough to destination
                //sets postition to destination
                transform.position = new Vector3(playerSettings.destination.x, playerSettings.currentPos.y, playerSettings.destination.z);
                playerSettings.currentPos = transform.position;

                if(playerSettings.isInMaze) { playerSettings.allowedToMove = true; }
                if (!playerSettings.isMouseMovement && !playerSettings.isInMaze) { playerUIDirections.CheckPlayerDirections();}
                playerSettings.isMoving = false;
            }
        }
    }

    public void CheckIfCanReachDestination()
    {
        var path = new NavMeshPath();
        agent.CalculatePath(playerSettings.destination, path);
        switch (path.status)
        {
            case NavMeshPathStatus.PathComplete:
                playerSettings.isMoving = true;
                agent.SetDestination(playerSettings.destination);
                playerSettings.currentPos = transform.position;
                
                if(playerSettings.destination.x < playerSettings.currentPos.x || playerSettings.destination.z > playerSettings.currentPos.z)
                { playerSettings.isMovingLeft = true; }
                else { playerSettings.isMovingLeft = false; }
                break;
            default:
                //Debug.Log("Can't move there");
                break;
        }
    }

    public void MoveOutsideScript(Vector3 pos) 
    {
        if (!playerSettings.isMoving)
        {
            playerSettings.destination = pos;
            CheckIfCanReachDestination();
        }
    }
}
