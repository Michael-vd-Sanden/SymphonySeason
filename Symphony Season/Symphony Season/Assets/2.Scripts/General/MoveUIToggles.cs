using UnityEngine;

public class MoveUIToggles : MonoBehaviour
{
    [SerializeField]
    private GameObject pushLeftUpControl, pushLeftDownControl, pushRightUpControl, pushRightDownControl;
    
    public void ActivatePlayerDirections(string direction, bool active)
    {/*
        switch (direction)
        {
            case "LeftUp":
                if (active) { pushLeftUpControl.SetActive(true); }
                else { pushLeftUpControl.SetActive(false); }
                break;
            case "RightUp":
                if (active) { pushRightUpControl.SetActive(true); }
                else { pushRightUpControl.SetActive(false); }
                break;
            case "LeftDown":
                if (active) { pushLeftDownControl.SetActive(true); }
                else { pushLeftDownControl.SetActive(false); }
                break;
            case "RightDown":
                if (active) { pushRightDownControl.SetActive(true); }
                else { pushRightDownControl.SetActive(false); }
                break;
        }*/
    }

    public void TurnOffDirections()
    {
        /*
        pushLeftDownControl.SetActive(false);
        pushLeftUpControl.SetActive(false);
        pushRightDownControl.SetActive(false);
        pushRightUpControl.SetActive(false);*/
    }
}
