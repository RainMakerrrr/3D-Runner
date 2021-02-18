using PlayerController.Movement;
using UnityEngine;
using Zenject;

namespace PlayerController.Input
{
    public class SwipeDetector : MonoBehaviour
    {
        [SerializeField] private float _minimumDistance = 0.2f;
        [SerializeField] private float _maximumTimer = 1f;
        
        private InputHandler _inputHandler;
        private PlayerMovement _playerMovement;
        
        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private float _startTime;
        private float _endTime;

        [Inject]
        private void Construct(InputHandler inputHandler, PlayerMovement playerMovement)
        {
            _inputHandler = inputHandler;
            _playerMovement = playerMovement;
        }

        private void OnEnable()
        {
            _inputHandler.OnStartTouch += StartTouchHandler;
            _inputHandler.OnEndTouch += EndTouchHandler;
        }

        private void StartTouchHandler(Vector2 position, float time)
        {
            _startPosition = position;
            _startTime = time;
        }

        private void EndTouchHandler(Vector2 position, float time)
        {
            _endPosition = position;
            _endTime = time;
            
            DetectSwipe();
        }

        private void DetectSwipe()
        {
            if (Vector3.Distance(_startPosition, _endPosition) >= _minimumDistance &&
                (_endTime - _startTime) <= _maximumTimer)
            {
                var direction = (_endPosition - _startPosition).normalized;
                CheckSwipeDirection(direction);
            }
        }

        private void CheckSwipeDirection(Vector2 direction)
        {
            if (Vector2.Dot(new Vector2(-0.5f,0f),direction) > 0.4f)
            {
                Debug.Log("left");
                _playerMovement.MoveLeftInput();
            }
            else if (Vector2.Dot(new Vector2(0.5f,0f),direction) > 0.4f)
            {
                Debug.Log("right");
                _playerMovement.MoveRightInput();
            }
        }
        
        private void OnDisable()
        {
            _inputHandler.OnStartTouch -= StartTouchHandler;
            _inputHandler.OnEndTouch -= EndTouchHandler;
        }
    }
}