using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStaticData : ScriptableObject
{
    [Header("MOVEMENT")]
    public float MaxSpeed = 10;
    public float Acceleration = 120;
    public float Deceleration = 120;
}
