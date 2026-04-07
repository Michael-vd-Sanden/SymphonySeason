using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class VictoryTrigger : MonoBehaviour
{
    public BPUiToggles uiToggles;
    public TriggerSetter CurtainCloser;
    public GameObject nextlvScreen;
    public MoveObject PlayerMover;
    public PlayerFollower playerFollower;
    public GameObject playerObject;
    [SerializeField] private BPGameInitiator gameInitiator;

    private PlayerInput PlayerInput;
    private PlayerMovement PMM;


    private void Awake()
    {
        PlayerInput = playerObject.GetComponent<PlayerInput>();
        PMM = playerObject.GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("seen player");
           // uiToggles.Victory();
           nextlvScreen.SetActive(true);
           CurtainCloser.SetTrigger();

            //gameInitiator.player.agent.enabled = false;
            //PlayerInput.enabled = false;
            //PMM.enabled = false;
            gameInitiator.victoryMover.StartMoving(true);
            playerFollower.ToggleMoving(1f);
        }
    }
}
