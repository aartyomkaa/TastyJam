using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerStaticData _movementStats;
        private Rigidbody2D _playerRb;

        // Input
        private Vector2 _inputVector;

        // Player state
        private HorizontalDirection _horizontalDirection;
        private Vector2 _frameVelocity;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 inputVector)
        {
            _inputVector = inputVector;
            HandleMove();
            ApplyMovement();
        }

        public void HandleMove()
        {
            // Horizontal
            if (_inputVector.x == 0)
            {
                _frameVelocity.x = Mathf.MoveTowards(_frameVelocity.x, 0, _movementStats.Deceleration * Time.fixedDeltaTime);
            }
            else
            {
                _frameVelocity.x = Mathf.MoveTowards(_frameVelocity.x, _inputVector.x * _movementStats.MaxSpeed, _movementStats.Acceleration * Time.fixedDeltaTime);
            }
            if (_inputVector.x > 0 && _horizontalDirection != HorizontalDirection.Right)
            {
                _horizontalDirection = HorizontalDirection.Right;
            }
            else if (_inputVector.x < 0 && _horizontalDirection != HorizontalDirection.Left)
            {
                _horizontalDirection = HorizontalDirection.Left;
            }

            // Vertical
            if (_inputVector.y == 0)
            {
                _frameVelocity.y = Mathf.MoveTowards(_frameVelocity.y, 0, _movementStats.Deceleration * Time.fixedDeltaTime);
            }
            else
            {
                _frameVelocity.y = Mathf.MoveTowards(_frameVelocity.y, _inputVector.y * _movementStats.MaxSpeed, _movementStats.Acceleration * Time.fixedDeltaTime);
            }

        }
        private void ApplyMovement() => _playerRb.velocity = _frameVelocity;

    }

    public enum HorizontalDirection
    {
        Left,
        Right
    }
}