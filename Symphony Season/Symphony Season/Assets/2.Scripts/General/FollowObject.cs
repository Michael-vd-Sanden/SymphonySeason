using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    public GameObject followPositionObject;
    public GameObject lookAtObject;

    [Header("-------------- Changeble Values")]
    public bool allowedToFollow;
    public bool followPosition, lookAt;

    private void Update()
    {
        if (allowedToFollow)
        {
            if (followPosition) { transform.position = followPositionObject.transform.position; }
            if(lookAt) { transform.LookAt(lookAtObject.transform) ; }              //points the forward position to the lookAtObject
        }
    }
}
