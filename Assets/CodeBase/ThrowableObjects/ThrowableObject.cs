using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.ThrowableObjects
{
    public class ThrowableObject : MonoBehaviour
    {
        [SerializeField] private ThrowableObjectStaticData _staticData;

        private Vector3 _targetDirection;
        private Vector3 _targetPoint;

        // Current state
        private bool _isMoving;


        private void Awake()
        {
            _isMoving = false;
        }

        private void FixedUpdate()
        {
            if (_isMoving)
            {
                if (transform.position != _targetPoint)
                {
                    Vector3 newPos = Vector3.Lerp(transform.position, _targetPoint, _staticData.Speed * Time.deltaTime);
                    transform.position = newPos;
                }
                else
                {
                    _isMoving = false;
                }
            }

        }

        public void Init(Vector2 targetPoint)
        {
            _targetDirection = (Vector3)targetPoint - transform.position;
            _targetDirection.Normalize();

            _targetPoint = transform.position + _targetDirection * _staticData.MaxDistance;

            _isMoving = true;
        }
    }
}
