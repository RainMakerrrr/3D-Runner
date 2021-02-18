using System;
using System.Collections;
using PlayerController.Animations;
using PlayerController.Input;
using UnityEngine;
using Zenject;

namespace PlayerController.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _laneDistance = 2.5f;
        [SerializeField] private float _movementSpeed = 3f;
        private int _currentLane = 1;

        private Rigidbody _rigidbody;

        private InputHandler _inputHandler;
        private PlayerCollision _playerCollision;
        private PlayerAnimation _playerAnimation;

        private Vector3 _targetPosition;
        
        public float Speed => _rigidbody.velocity.magnitude;
        
        public float MovementSpeed
        {
            set
            {
                if (value > 0)
                    _movementSpeed = value;
            }
        }

        [Inject]
        private void Construct(Rigidbody rigidbody, InputHandler inputHandler, PlayerCollision playerCollision, PlayerAnimation playerAnimation)
        {
            _rigidbody = rigidbody;
            _inputHandler = inputHandler;
            _playerCollision = playerCollision;
            _playerAnimation = playerAnimation;
        }

        private void Start()
        {
            _inputHandler.OnMoveLeft += MoveLeftInput;
            _inputHandler.OnMoveRight += MoveRightInput;
            
            CheckAndSetCurrentTrack();
            
        }

        private void Update()
        {
            MoveForward();
            CheckCurrentTrack();
            
        }

        private void CheckCurrentTrack()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out var hit))
            {
                var track = hit.collider.GetComponent<Track>();
                if (track)
                {
                    _currentLane = track.Order;
                }
            }
        }

        private void CheckAndSetCurrentTrack()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out var hit))
            {
                var track = hit.collider.GetComponent<Track>();
                if (track)
                {
                    _currentLane = track.Order;
                    transform.position = track.TrackPosition.position;
                }
            }
        }
        
        private void MoveForward()
        {
            var velocity = _rigidbody.velocity;
            velocity = new Vector3(velocity.x, velocity.y, _movementSpeed);
            Debug.Log(_rigidbody.velocity.magnitude);
            
            _rigidbody.velocity = velocity;
        }

        public void MoveLeftInput()
        {
            if (_playerCollision.IsPushing || _playerAnimation.InAction) return;

            if (_currentLane > 0)
            {
                _currentLane--;
                
                var position = transform.position;
                _targetPosition = new Vector3(position.x - _laneDistance, position.y, position.z);
                
                _playerAnimation.SetDodgeLeftAnimation();
                StartCoroutine(MoveToSide());
                
            }
            
        }
        
        public void MoveRightInput()
        {
            if (_playerCollision.IsPushing || _playerAnimation.InAction) return;

            if (_currentLane < 3)
            {
                _currentLane++;
                
                var position = transform.position;
                _targetPosition = new Vector3(position.x + _laneDistance, position.y, position.z);
                
                _playerAnimation.SetDodgeRightAnimation();
                StartCoroutine(MoveToSide());
            }
        }

        private IEnumerator MoveToSide()
        {
            while (Math.Abs(transform.position.x - _targetPosition.x) > 0.05f)
            {
                transform.position = Vector3.Lerp(transform.position,_targetPosition, 8f * Time.deltaTime);
                Debug.Log(_rigidbody.velocity.magnitude);
                yield return null;
            }
        }
        private void OnDisable()
        {
            _inputHandler.OnMoveLeft -= MoveLeftInput;
            _inputHandler.OnMoveRight -= MoveRightInput;
        }
    }
}