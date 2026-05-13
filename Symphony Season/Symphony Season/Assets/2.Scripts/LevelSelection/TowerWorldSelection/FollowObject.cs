using UnityEngine;

public class FollowObject : MonoBehaviour
{
    
    public GameObject followPositionObject, lookAtObject;
    public bool allowedToFollow, followPosition, lookAt;

    private void Update()
    {
        if (allowedToFollow)
        {
            if (followPosition) { transform.position = followPositionObject.transform.position; }
            if(lookAt) { transform.LookAt(lookAtObject.transform) ; }
        }
    }
}
