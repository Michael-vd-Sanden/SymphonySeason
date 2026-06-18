using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    public float moveSpeed;
    public float sampleDistance;        //for navmesh
    public Vector3 baseOffset;
    public Vector3 modelOffset;
    public Vector3 targetMargin;        //for checking if the player has reached the target within this value
}
