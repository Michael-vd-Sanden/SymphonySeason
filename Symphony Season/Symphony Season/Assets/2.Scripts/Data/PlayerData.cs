using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Vector3 currentPos, destination;
    public string moveDirection;

    public bool isInMaze;
    public bool isMouseMovement;
    public bool isHoldingSomething;
    public bool allowedToMove;
    public bool isMoving;
    public bool stoppedMoving; //toggle for checks
    public bool isMovingLeft;
    public bool canBeOverUI;
    public bool isPressingMove;
}
