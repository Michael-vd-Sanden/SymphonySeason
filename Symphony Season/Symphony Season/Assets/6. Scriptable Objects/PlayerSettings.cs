using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    public float moveSpeed;
    public float sampleDistance;
    public Vector3 baseOffset;
    public Vector3 modelOffset;
    public Vector3 targetMargin;
}
