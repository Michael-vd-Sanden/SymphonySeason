using UnityEngine;

public class CrystalMoverScript : MonoBehaviour
{
    [SerializeField] private MoveObject moveCrystal, moveShadow;

    public void MoveCrystal(int note)
    {
        moveCrystal.MoveTo(note);
        moveShadow.MoveTo(note);
    }
}
