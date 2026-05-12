using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform followPosition, followRotation;
    [SerializeField] private float moveSpeed = 3f, orbitDamping = 10f;

    public Vector3 localRot, startRot, moveOffset, moveTo;
    public bool allowedRotation;

    public Vector3 upVector;
    private void Start()
    {
        startRot = transform.eulerAngles;
        moveOffset = transform.position - followPosition.position;

    }

    private void LateUpdate()
    {
        /*Vector3 toPos = followObject.position + moveOffset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, toPos, orbitDamping);
        transform.position = smoothPos;
        transform.LookAt(orbitObject);*/
        /*
        moveTo = followPosition.position;

        transform.position = followPosition.up + moveOffset; //fout, geen idee

       // transform.position = followObject.localPosition + moveOffset;
        localRot.x = followRotation.rotation.x + startRot.x;
        localRot.z = followRotation.rotation.z + startRot.z;

        Quaternion qt = Quaternion.Euler(localRot.x, 0f, localRot.z); //maybe switch these things
        //transform.rotation = qt;
        */

        
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


        transform.position = followPosition.position;

        Vector3 temp = new Vector3(0f, followRotation.rotation.y, followRotation.rotation.z);
        transform.LookAt(followRotation);
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
