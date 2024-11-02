using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ThrowableObjectStaticData : ScriptableObject
{
    public float Speed = 10;
    public float MaxDistance = 5;

    [Tooltip("Distance from the target point where object will stop")]
    public float DistanceEpsilon = 0.1f;
}
