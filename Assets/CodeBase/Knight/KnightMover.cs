using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightMover : MonoBehaviour
    {
        private float _moveSpeed;
        private SpriteRenderer _spriteRenderer;

        public void Construct(float moveSpeed) => 
            _moveSpeed = moveSpeed;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Move(Transform target)
        {
            
            transform.position = Vector3.Lerp(transform.position, target.position, _moveSpeed * Time.deltaTime);
            
            //Vector3 vectorToKnight = target.transform.position - transform.position;
        
            //transform.Translate(vectorToKnight * (_moveSpeed * Time.deltaTime));
        }
    }
}