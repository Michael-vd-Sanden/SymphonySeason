using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    //Settings
    public float moveSpeed;
    public float sampleDistance;
    public Vector3 baseOffset;
    public Vector3 modelOffset;
    public Vector3 targetMargin;


    //NonSerialized in-game data, not saved after play
    [NonSerialized] public Vector3 currentPos, destination;
    [NonSerialized] public string moveDirection;

    [NonSerialized] public bool isInMaze;
    [NonSerialized] public bool isMouseMovement;
    [NonSerialized] public bool isHoldingSomething;
    [NonSerialized] public bool allowedToMove;
    [NonSerialized] public bool isMoving;
    [NonSerialized] public bool stoppedMoving; //toggle for checks
    [NonSerialized] public bool isMovingLeft;
    [NonSerialized] public bool canBeOverUI;
    [NonSerialized] public bool isPressingMove;
}
