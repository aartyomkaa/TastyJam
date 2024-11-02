using System.Collections;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightMover : MonoBehaviour
    {
        private float _moveSpeed;

        public void Construct(float moveSpeed) => 
            _moveSpeed = moveSpeed;

        public void Move(Transform target)
        {
            Debug.Log("1");

            StartCoroutine(Moving(target));
        }

        private IEnumerator Moving(Transform target)
        {
            while (Vector2.Distance(transform.position, target.position) < 1f)
            {
                Vector2 direaction = transform.position - target.position;
            
                transform.Translate(direaction * _moveSpeed * Time.deltaTime);
                
                yield return null;
            }
        }
    }
}