using UnityEngine;

public class TriggerSetter : MonoBehaviour
{
    public Animator[] Animators;
    public string TriggerToSet;

    public void SetTrigger()
    {
        for (int i = 0; i < Animators.Length; i++)
        {
            Animators[i].SetTrigger(TriggerToSet);
        }
    }
}
