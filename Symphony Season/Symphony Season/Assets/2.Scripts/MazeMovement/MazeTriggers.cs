using UnityEngine;

public class MazeTriggers : MonoBehaviour
{
    public MazePuzzle mazePuzzle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (this.gameObject.tag)
            {
                case "End":
                    mazePuzzle.EndMaze();
                    break;
                case "":
                    break;
            }
        }
    }
}
