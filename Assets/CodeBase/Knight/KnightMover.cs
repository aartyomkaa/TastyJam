using CodeBase.Logic.Utilities;
using UnityEngine;

namespace CodeBase.Knight
{
    public class KnightMover : MonoBehaviour
    {
        [SerializeField] private KnightAnimationsController _animator;
        
        private float _moveSpeed;
        private HorizontalDirection _horizontalDirection;

        public void Construct(float moveSpeed) => 
            _moveSpeed = moveSpeed;

        public void Move(Transform target)
        {
            Vector2 moveDirection = transform.position - target.transform.position;
            
            if (moveDirection.x > 0 && _horizontalDirection != HorizontalDirection.Right)
            {
                _horizontalDirection = HorizontalDirection.Right;
                _animator.Turn();
            }
            else if (moveDirection.x < 0 && _horizontalDirection != HorizontalDirection.Left)
            {
                _horizontalDirection = HorizontalDirection.Left;
                _animator.Turn();
            }
            
            _animator.Run();
            transform.position = Vector3.Lerp(transform.position, target.position, _moveSpeed * Time.deltaTime);
        }
    }
}