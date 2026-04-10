using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField] private MoveUIToggles moveUIToggles;
    [SerializeField] private BPUiToggles bpUIToggles;
    [SerializeField] private TriggerSetter curtainCloser;
    [SerializeField] private MoveObject playerMover;
    [SerializeField] private NavMeshAgent playerAgent;

    [SerializeField] private PlayerData playerData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            moveUIToggles.TurnOffDirections();   //turn off move arrows    
          
            curtainCloser.SetTrigger();          //close curtain
            bpUIToggles.Victory();               //victory screen active

            playerAgent.enabled = false;
            playerMover.StartMoving(true);
            playerData.isMoving = true;
            playerData.isPressingMove = false;  //so it doesn't try to calculate path
            playerData.destination = playerMover.targetPos;
        }
    }
}
