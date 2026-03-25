using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("-------------- Changeble Values")]
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private Vector3[] positions;

    [Header("-------------- Background Values (do not change)")]
    public bool isMoving = false;
    private int pos;
    private Vector3 currentPos, targetPos;

    private void Update()
    {
        if (isMoving) 
        { 
            currentPos = transform.position;

            var step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(currentPos, targetPos, step);

            if(currentPos == targetPos) 
            { 
                isMoving = false;
            }
        }
    }

    public void StartMoving(bool isUp)
    {
        Debug.Log("Start move?");
        if(!isMoving)
        {
            Debug.Log("should move");
            if(isUp && pos < positions.Length - 1) { pos++; }
            else if (!isUp && pos > 0) { pos--; }

            targetPos = positions[pos];
            isMoving = true;
        }
    }
}
