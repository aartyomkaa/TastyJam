using CodeBase.ThrowableObjects;
using UnityEngine;

namespace CodeBase.Player
{
    public class ThrowAction : MonoBehaviour
    {
        [SerializeField] private Transform _objectsTransform;
        private PlayerState _playerState;

        public void Init(PlayerState playerState)
        {
            _playerState = playerState;
        }

        public void Throw(Vector2 targetPoint)
        {
            if (_playerState.ObjectInHands != null)
            {
                GameObject objectToThrow = _playerState.ObjectInHands;
                objectToThrow.transform.SetParent(_objectsTransform, true);
                objectToThrow.GetComponent<ThrowableObject>().InitThrow(targetPoint);

                _playerState.ObjectInHands = null;
            }

        }
    }
}
