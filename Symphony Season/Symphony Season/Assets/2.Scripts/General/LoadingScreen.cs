using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject screenVisual;

    public void Show()
    {
        screenVisual.SetActive(true);
    }

    public void Hide()
    {
        screenVisual.SetActive(false);
    }
}
