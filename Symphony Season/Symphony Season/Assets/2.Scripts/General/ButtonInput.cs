using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ButtonInput : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerMovement pMovement;
    //[SerializeField] private BlockPuzzleManager manager;
    private Vector3 playerDestination;

    private void Update()
    {
        if(playerSettings.isPressingMove) 
        {
            MovePlayer();
        }
    }

    public void MovePlayer()
    {
        if (!playerSettings.isHoldingSomething && !playerSettings.isMoving && !playerSettings.isMouseMovement)
        {
            Vector3 temp = new Vector3(0f, 0f, 0f);
            playerSettings.currentPos = transform.position;
            switch (playerSettings.moveDirection)
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
            playerDestination = playerSettings.currentPos + temp;
            pMovement.MoveOutsideScript(playerDestination);
        }
    }

    public void onPressMove(string direction)
    {

        if (!playerSettings.isHoldingSomething)
        {
            playerSettings.moveDirection = direction;
            playerSettings.isPressingMove = true;
        }
        else
        {
            //manager.currentSelectedBlock.moveDirection = direction;
            //manager.currentSelectedBlock.isPressingBlockMove = true;
        }
    }

    public void onReleaseMove()
    {
        if (!playerSettings.isHoldingSomething)
        {
            playerSettings.isPressingMove = false;
        }
        else
        {
            //manager.currentSelectedBlock.isPressingBlockMove = false;
        }
    }  
}
