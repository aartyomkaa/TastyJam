using CodeBase.StaticData;
using System.Collections;
using UnityEngine;

namespace CodeBase.ThrowableObjects
{
    public class ThrowableObject : MonoBehaviour
    {
        [SerializeField] private ThrowableObjectStaticData _staticData;

        private ThrowableObjectState _state;

        private Vector3 _targetDirection;
        private Vector3 _targetPoint;

        private DisappearableObject _disappear;

        private float _idleTime;


        public bool CanBePickedUp => _state == ThrowableObjectState.Idle || _state == ThrowableObjectState.Disappearing;

        private void Awake()
        {
            _disappear = GetComponent<DisappearableObject>();
            _state = ThrowableObjectState.Idle;

        }

        private void OnEnable()
        {
            if (_state != ThrowableObjectState.PickedUp)
            {
                _state = ThrowableObjectState.Idle;
            }
        }

        private void Update()
        {
            if (_state == ThrowableObjectState.Idle)
            {
                _idleTime += Time.deltaTime;
                if (_idleTime > _staticData.TimeToDisappear)
                {
                    _state = ThrowableObjectState.Disappearing;
                    _disappear.StartDisappear();
                }
            }
        }


        private void FixedUpdate()
        {
            if (_state == ThrowableObjectState.Moving)
            {
                if (Vector3.Distance(transform.position, _targetPoint) > _staticData.DistanceEpsilon)
                {
                    Vector3 newPos = Vector3.Lerp(transform.position, _targetPoint, _staticData.Speed * Time.deltaTime);
                    transform.position = newPos;
                }
                else
                {
                    _state = ThrowableObjectState.Idle;
                    _idleTime = 0;
                }
            }
        }

        public void InitThrow(Vector2 targetPoint)
        {
            _targetDirection = (Vector3)targetPoint - transform.position;
            _targetDirection.Normalize();

            _targetPoint = transform.position + _targetDirection * _staticData.MaxDistance;

            _state = ThrowableObjectState.Moving;
        }

        public void PickedUp()
        {
            if (_state == ThrowableObjectState.Disappearing)
            {
                _disappear.StopDisappear();
            }

            _state = ThrowableObjectState.PickedUp;
        }
    }
}
