using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ButtonInput : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerMovement pMovement;
    //[SerializeField] private BlockPuzzleManager manager;
    private Vector3 playerDestination;

    private void Update()
    {
        if(playerData.isPressingMove) 
        {
            MovePlayer();
        }
    }

    public void MovePlayer()
    {
        if (!playerData.isHoldingSomething && !playerData.isMoving && !playerData.isMouseMovement)
        {
            Vector3 temp = new Vector3(0f, 0f, 0f);
            playerData.currentPos = transform.position;
            switch (playerData.moveDirection)
            {
                case "LeftUp":
                    temp = new Vector3(0f, 0f, 1f);
                    break;
                case "RightUp":
                    temp = new Vector3(1f, 0f, 0f);
                    break;
                case "LeftDown":
                    temp = new Vector3(-1f, 0f, 0f);
                    break;
                case "RightDown":
                    temp = new Vector3(0f, 0f, -1f);
                    break;
            }
            playerDestination = playerData.currentPos + temp;
            pMovement.MoveOutsideScript(playerDestination);
        }
    }

    public void onPressMove(string direction)
    {
        if (!playerData.isHoldingSomething && playerData.allowedToMove)
        {
            playerData.moveDirection = direction;
            playerData.isPressingMove = true;
        }
    }

    public void onReleaseMove()
    {
        if (!playerData.isHoldingSomething)
        {
            playerData.isPressingMove = false;
        }
    }  
}
