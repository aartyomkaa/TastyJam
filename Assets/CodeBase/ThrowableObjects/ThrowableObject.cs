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

        public bool CanBePickedUp => !_isMoving;

        private void Awake()
        {
            _isMoving = false;
        }

        private void FixedUpdate()
        {
            if (_isMoving)
            {
                if (Vector3.Distance(transform.position, _targetPoint) > _staticData.DistanceEpsilon)
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

        public void InitThrow(Vector2 targetPoint)
        {
            _targetDirection = (Vector3)targetPoint - transform.position;
            _targetDirection.Normalize();

            _targetPoint = transform.position + _targetDirection * _staticData.MaxDistance;

            _isMoving = true;
        }

        public void PickedUp()
        {
            _isMoving = false;
        }
    }
}
