using UnityEngine;

public class LightbeamScript : MonoBehaviour
{
    public float length = 1f;
    public float maxlength = 20f;

    [SerializeField] private Transform beamTransform;
    public bool isHittingSomething;
    public Transform hitObject;

    private void Update()
    {
        Vector3 temp = new Vector3(1, 1, length);
        beamTransform.localScale = temp;
        if (!isHittingSomething) length = maxlength;
        else UpdateLength(Vector3.Distance(transform.position, hitObject.position));
    }

    private void UpdateLength(float newLength)
    {
        if(newLength > maxlength) length = maxlength;
        if(newLength < 0) length = 0.1f;

        length = newLength;
    }
}
