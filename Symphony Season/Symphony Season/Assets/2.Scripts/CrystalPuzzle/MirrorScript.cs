using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    [SerializeField] private GameObject frontLightBeam, backLightBeam;
    [SerializeField] private LightbeamScript hitLightbeam;
    [SerializeField] private TriggerMirrorScript[] triggerMirrors;
    [SerializeField] private TriggerMirrorScript triggeredMirror;

    public bool isTriggerRunning;

    public void TriggerMirror(bool isFront, bool turnOn, TriggerMirrorScript mir)
    {
        if (!isTriggerRunning)
        {
            StartCoroutine(TriggeredMirror(isFront, turnOn, mir));
        }
    }

    private IEnumerator TriggeredMirror(bool isFront, bool turnOn, TriggerMirrorScript mir)
    {
        isTriggerRunning = true;

        triggeredMirror = mir;

        if (turnOn)
        {
            hitLightbeam = mir.hitCollider.GetComponentInParent<LightbeamScript>();
            hitLightbeam.hitObject = this.transform;
            hitLightbeam.isHittingSomething = true;

            if (triggerMirrors[0].isBeingTriggered && triggerMirrors[1].isBeingTriggered)
            {
                Debug.Log("both");
                /*float length1 = Vector3.Distance(triggerMirrors[0].transform.position, hitLightbeam.transform.position);
                float length2 = Vector3.Distance(triggerMirrors[1].transform.position, hitLightbeam.transform.position);

                if (length1 < length2) { frontLightBeam.SetActive(true); }
                else { backLightBeam.SetActive(true); }*/

            }

            if (isFront) frontLightBeam.SetActive(true);
            else if (!isFront) backLightBeam.SetActive(true);
        }
        else
        {
            if (hitLightbeam == mir.hitCollider.GetComponentInParent<LightbeamScript>())
            {
                frontLightBeam.SetActive(false);
                backLightBeam.SetActive(false);

                if (hitLightbeam != null)
                {
                    hitLightbeam.isHittingSomething = false;
                    hitLightbeam.hitObject = null;
                    hitLightbeam = null;
                }
            }
        }

        yield return new WaitForSecondsRealtime(0.1f);

        isTriggerRunning = false;
        yield return null;
    }

    public void UnTriggerMirror(TriggerMirrorScript mir)
    {
        if (triggeredMirror == mir)
        {
            if (isTriggerRunning)
            {
                frontLightBeam.SetActive(false);
                backLightBeam.SetActive(false);

                if (hitLightbeam != null)
                {
                    hitLightbeam.isHittingSomething = false;
                    hitLightbeam.hitObject = null;
                    hitLightbeam = null;
                }

                isTriggerRunning = false;
                triggeredMirror = null;
            }
        }
    }


    /*
    private void Update()
    {
        if(mirrorFront.isBeingTriggered) 
        {
            TriggerMirror(frontLightBeam, mirrorFront);
            UnTriggerMirror(backLightBeam);
        }
        else if (mirrorBack.isBeingTriggered) 
        {
            TriggerMirror(backLightBeam, mirrorBack);
            UnTriggerMirror(frontLightBeam);
        }
        else if (!mirrorFront.isBeingTriggered && !mirrorBack.isBeingTriggered) 
        { 
            UnTriggerMirror(frontLightBeam);
            UnTriggerMirror(backLightBeam);
        }
    }

    private void TriggerMirror(GameObject beam, TriggerMirrorScript mirror)
    {
       // if(!hasTriggered) 
       // {
            beam.SetActive(true);
            hitLightbeam = mirror.hitCollider.GetComponentInParent<LightbeamScript>();
            hitLightbeam.hitObject = this.transform;
            hitLightbeam.isHittingSomething = true;


           /* hasTriggered = true;
            hasUnTriggerd = false;
        }
    }
    private void UnTriggerMirror(GameObject beam)
    {
        //if(!hasUnTriggerd)
       // {
            beam.SetActive(false);
            if (hitLightbeam != null)
            {
                hitLightbeam.isHittingSomething = false;
                hitLightbeam.hitObject = null;
                hitLightbeam = null;
            }


         /*   hasUnTriggerd = true;
            hasTriggered = false;
        }
    }*/
}
