using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MoveBlockScript : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    public PlayerMovement playerMovement;   //set in initiator
    public MeshRenderer colourBlockRenderer, colourQuestionRenderer, colourNoteRenderer;
    public GameObject questionNotification, noteNotification;
    public BlockPuzzleManager manager;    //set in initiator
    public ColourChanger colourChanger;     //set in initiator
    public GameObject pushUpControl, pushDownControl;

    [Header("-------------- Changeble Values")]
    public float playerDistance;
    public float wallDistance;
    public bool isRightDirection; //set for every object
    public string blockNote;
    public int materialInArray;

    [Header("-------------- Background Values (do not change)")]
    public Material colourMaterial;
    //background values
    public bool objectAbleToMove;
    public bool upAllowed;
    public bool downAllowed;
    //positioning
    public Vector3 objectCurrentPos, objectTargetPos, playerTargetPos, playerCurrentPos;
    public bool isMoving = false;
    public bool playerIsFront; //on which side the player is (true = front, false = back)
    //smooth movement
    [SerializeField] AnimationCurve stepEase = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));
    [SerializeField] AnimationCurve stepHeightShape = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));
    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float stepDuration = 0.3f;
    public float stepTime;
    public string moveDirection;
    public bool isPressingBlockMove = false, checkedDirections;

    private void Update()
    {
        if (isPressingBlockMove && checkedDirections) 
        {
            manager.SetBlockTargetPos(this);
        }
        if(isMoving)
        {
            Move();
        }
    }

    public void EnteredTriggerInChild(Collider c, bool isFront)
    {
        //Debug.Log(c.name.ToString() + " detected");
        playerIsFront = isFront;
        manager.EnteredTrigger(this);
    }

    public void ExitedTriggerInChild(Collider c)
    {
        //Debug.Log(c.name.ToString() + " left");
        manager.ExitedTrigger(this);
    }

    public void PressedMove(string direction)
    {
        manager.onPressMove(direction);
    }
    public void ReleasedMove()
    {
        manager.onReleaseMove();
    }

    private void Move()
    {
        stepTime += Time.deltaTime;
        float progress = stepEase.Evaluate(stepTime / stepDuration);

        Vector3 newPos = Vector3.Lerp(objectCurrentPos, objectTargetPos, progress);
        newPos.y += stepHeight * stepHeightShape.Evaluate(progress);

        //Debug.Log("targetPos: " + newPos.ToString());
        playerMovement.MoveOutsideScript(playerTargetPos);
        this.gameObject.transform.position = newPos;
        if (progress >= 1f)
        {
            isMoving = false;
            manager.CheckIfAllowedToMove();
        }
    }
}
