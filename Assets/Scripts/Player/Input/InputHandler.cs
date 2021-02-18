using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerController.Input
{
    public class InputHandler : MonoBehaviour
    {
        public event Action<Vector2, float> OnStartTouch;
        public event Action<Vector2, float> OnEndTouch;
        
        public event Action OnMoveLeft;
        public event Action OnMoveRight;
        
        private PlayerControls _playerControls;

        private void OnEnable()
        {
            _playerControls = new PlayerControls();
            _playerControls.Enable();

            _playerControls.PlayerMovement.MovingLeft.started += ctx => OnMoveLeft?.Invoke();
            _playerControls.PlayerMovement.MovingRight.started += ctx => OnMoveRight?.Invoke();

            _playerControls.PlayerMovement.PrimaryContact.started += StartTouchHandler;
            _playerControls.PlayerMovement.PrimaryContact.canceled += EndTouchHandler;

        }

        private void StartTouchHandler(InputAction.CallbackContext context)
        {
            OnStartTouch?.Invoke(Camera.main.ScreenToWorld(_playerControls.PlayerMovement.PrimaryPosition.ReadValue<Vector2>()),
                (float) context.startTime);
        }

        private void EndTouchHandler(InputAction.CallbackContext context)
        {
            OnEndTouch?.Invoke(Camera.main.ScreenToWorld(_playerControls.PlayerMovement.PrimaryPosition.ReadValue<Vector2>()), 
                (float) context.time);
        }
        
        private Vector3 ScreenToWorld(Camera camera, Vector3 position)
        {
            position.z = camera.nearClipPlane;
            return camera.ScreenToWorldPoint(position);
        }
        
        private void OnDisable() => _playerControls.Disable();
    }
}