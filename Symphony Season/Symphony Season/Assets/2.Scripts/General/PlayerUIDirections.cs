using UnityEditor;
using UnityEngine;

public class PlayerUIDirections : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private UIToggles UIToggles;
    [SerializeField] private Transform globalRoot;

    [Header("-------------- Changeble Values")]
    public int layer;

    [Header("-------------- Background Values (do not change)")]
    public int layerAsLayerMask;

    private void Update()
    {
        if(playerSettings.stoppedMoving)
        {
            CheckPlayerDirections();
            playerSettings.stoppedMoving = false;
        }
    }

    public void CheckPlayerDirections()
    {
        if (!playerSettings.isHoldingSomething && !playerSettings.isMouseMovement)
        {
            Transform t = globalRoot;
            Vector3 playerPos = transform.position + new Vector3(0f, -0.5f, 0f);
            Vector3 rayDirect;
            bool able;

            for (int check = 0; check < 4; check++)
            {

                switch (check)
                {
                    case 0:
                        rayDirect = t.forward;
                        break;
                    case 1:
                        rayDirect = t.right;
                        break;
                    case 2:
                        rayDirect = -t.right;
                        break;
                    case 3:
                        rayDirect = -t.forward;
                        break;
                    default:
                        rayDirect = t.forward;
                        break;
                }

                RaycastHit hit;
                if (Physics.Raycast(playerPos, rayDirect, out hit, 3f, layerAsLayerMask))
                {

                    if (hit.distance <= 1f)
                    {//too close
                        //Debug.Log("hit " + hit.collider.name);
                        //Debug.DrawRay(playerPos, rayDirect * 2f, Color.red, 2f);
                        able = false;
                    }
                    else
                    {
                        //Debug.DrawRay(playerPos, rayDirect * 2f, Color.green, 2f);
                        able = true;
                    }
                }
                else
                {
                    //Debug.DrawRay(playerPos, rayDirect * 2f, Color.green, 2f);
                    able = true;
                }

                switch (check)
                {
                    case 0:
                        UIToggles.ActivatePlayerDirections("LeftUp", able);
                        break;
                    case 1:
                        UIToggles.ActivatePlayerDirections("RightUp", able);
                        break;
                    case 2:
                        UIToggles.ActivatePlayerDirections("LeftDown", able);
                        break;
                    case 3:
                        UIToggles.ActivatePlayerDirections("RightDown", able);
                        break;
                }
            }
        }
    }
}
