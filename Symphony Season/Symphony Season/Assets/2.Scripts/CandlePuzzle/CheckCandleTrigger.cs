using UnityEngine;

public class CheckCandleTrigger : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private CandleScript candle;

    private void OnTriggerEnter(Collider other)
    {
        candle.igniteBtn.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        candle.igniteBtn.SetActive(false);
        candle.extinguishBtn.SetActive(false);
    }
}
