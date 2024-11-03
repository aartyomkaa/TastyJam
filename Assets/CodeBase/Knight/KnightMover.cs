using System.Collections;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightMover : MonoBehaviour
    {
        private float _moveSpeed;
        private Coroutine _moveCoroutine;

        private bool _isMoving = false;

        public void Construct(float moveSpeed) => 
            _moveSpeed = moveSpeed;

        public void Move(Transform target)
        {
            if (_isMoving)
                return;

            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            
            _moveCoroutine = StartCoroutine(Moving(target));
        }

        private IEnumerator Moving(Transform target)
        {
            _isMoving = true;
            
            while (Vector3.Distance(transform.position, target.position) > 1f)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, _moveSpeed * Time.deltaTime);
                
                yield return null;
            }

            _isMoving = false;
        }
    }
}