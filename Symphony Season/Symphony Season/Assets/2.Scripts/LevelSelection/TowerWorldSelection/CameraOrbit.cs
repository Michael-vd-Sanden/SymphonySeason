using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform followObject, orbitObject;
    [SerializeField] private float moveSpeed = 3f, orbitDamping = 10f;

    public Vector3 localRot, startRot, moveOffset;
    public bool allowedRotation;
    private void Start()
    {
        startRot = transform.eulerAngles;
        moveOffset = transform.position - followObject.position;
    }

    private void LateUpdate()
    {
        Vector3 toPos = followObject.position + moveOffset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, toPos, orbitDamping);
        transform.position = smoothPos;
        transform.LookAt(orbitObject);
    }

    private void Update()
    {
        /*if(allowedRotation) 
        {
            transform.position = orbitObject.position + moveOffset;

            localRot.x = (orbitObject.rotation.x * moveSpeed) + startRot.x;
            localRot.y = (orbitObject.rotation.y * moveSpeed) + startRot.y;
            localRot.z = (orbitObject.rotation.z * moveSpeed) + startRot.z;

            //clamping for more polished look, can't go above or below these values
            //localRot.y = Mathf.Clamp(localRot.y, 0f, 90f); // or 80f

            Quaternion qt = Quaternion.Euler(localRot.x, localRot.y, localRot.z); //maybe switch these things
            transform.rotation = qt;
            //transform.rotation = Quaternion.Lerp(transform.rotation, qt, Time.deltaTime * orbitDamping);
        }*/
    }

    public void AllowOrbit()
    {
        allowedRotation = true;
    }
    public void DisAllowOrbit()
    {
        allowedRotation = false;
    }
}
