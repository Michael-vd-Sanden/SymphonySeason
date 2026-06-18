using UnityEngine;

public class PopupRotator : MonoBehaviour
{
    [SerializeField] private GameObject GlobalRoot;

    public void SetRotator()
    {
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            GlobalRoot.transform.eulerAngles.y - 45,
            transform.eulerAngles.z
            );
    }
}
