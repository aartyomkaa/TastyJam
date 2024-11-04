using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightMover : MonoBehaviour
    {
        private float _moveSpeed;
        private Coroutine _moveCoroutine;
        private Rigidbody2D _rb;
        private SpriteRenderer _spriteRenderer;

        public void Construct(float moveSpeed) => 
            _moveSpeed = moveSpeed;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Move(Transform target)
        {
            Vector3 vectorToKnight = target.transform.position - transform.position;
        
            transform.Translate(vectorToKnight * (_moveSpeed * Time.deltaTime));
        }
    }
}