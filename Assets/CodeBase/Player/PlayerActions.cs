using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Player
{
    public class PlayerActions : MonoBehaviour
    {
        public GameObject _objectToThrow; // temp

        private PlayerInputActions _playerInputActions;
        private Camera _camera;

        private PlayerMovement _playerMovement;
        private PlayerAim _playerAim;
        private ThrowAction _throwAction;

        // Input
        private Vector2 _inputVector;
    
        private void Awake()
        {
            // Input Action
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
            _playerInputActions.Player.Aim.performed += OnAim;
            _playerInputActions.Player.Throw.performed += OnThrow;

            // Camera
            _camera = Camera.main;

            // Actions
            _throwAction = GetComponent<ThrowAction>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAim = GetComponent<PlayerAim>();

        }

        private void Update()
        {
            _inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _playerMovement.Move(_inputVector);
        }

        private void OnAim(InputAction.CallbackContext context)
        {
            Vector2 newPoint = _camera.ScreenToWorldPoint(context.ReadValue<Vector2>());
            _playerAim.UpdateAimCoords(newPoint);
        }

        private void OnThrow(InputAction.CallbackContext context)
        {
            _throwAction.Throw(_playerAim.CurrentCoords, _objectToThrow);
        }
    }
}
