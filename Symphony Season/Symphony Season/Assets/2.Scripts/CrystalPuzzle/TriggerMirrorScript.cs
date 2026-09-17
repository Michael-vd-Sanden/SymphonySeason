using UnityEngine;

public class TriggerMirrorScript : MonoBehaviour
{
    public bool isBeingTriggered = false;
    public string tagToCheck;
    public Collider hitCollider;

    [SerializeField] private MirrorScript mirror;
    public bool isFront;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCheck))
        {
            isBeingTriggered = true;
            hitCollider = other;
            mirror.TriggerMirror(isFront, true, this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToCheck))
        {
            isBeingTriggered = false;
            hitCollider = other;
            mirror.TriggerMirror(isFront, false, this);
        }
    }
}
