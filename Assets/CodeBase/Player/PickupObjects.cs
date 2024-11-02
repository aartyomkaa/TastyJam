using CodeBase.ThrowableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Player
{
    public class PickupObjects : MonoBehaviour
    {
        [SerializeField] private Transform handsArea;
        private PlayerState _playerState;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("ThrowableObject"))
            {
                ThrowableObject throwableObject = collision.GetComponent<ThrowableObject>();
                if (throwableObject.CanBePickedUp)
                {

                    collision.transform.SetParent(handsArea, false);
                    collision.transform.localPosition = Vector3.zero;
                    _playerState.ObjectInHands = collision.gameObject;

                    throwableObject.PickedUp();
                }
            }
        }

        public void Init(PlayerState playerState)
        {
            _playerState = playerState;
        }
    }
}