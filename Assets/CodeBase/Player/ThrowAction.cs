using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAction : MonoBehaviour
{
    [SerializeField] private Transform _throwInitPosition;

    public void Throw(Vector2 targetPoint, GameObject objectToThrow)
    {
        GameObject instantiatedObject = Instantiate(objectToThrow, _throwInitPosition.position, Quaternion.identity);

        instantiatedObject.GetComponent<ThrowableObject>().Init(targetPoint);
    }
}
