using System;
using PlayerController.Animations;
using PlayerController.Input;
using PlayerController.Movement;
using PlayerController.Weight;
using UnityEngine;
using Zenject;

namespace PlayerController
{
    public class PlayerState : MonoBehaviour
    {
        public event Action<State> OnStateChanged;
        
        [SerializeField] private State _state;

        private PlayerMovement _playerMovement;
        private PlayerWeight _playerWeight;
        private PlayerAnimation _playerAnimation;
        private InputHandler _inputHandler;
        
        [Inject]
        private void Construct(PlayerMovement playerMovement, PlayerWeight playerWeight, PlayerAnimation playerAnimation, InputHandler inputHandler)
        {
            _playerMovement = playerMovement;
            _playerWeight = playerWeight;
            _playerAnimation = playerAnimation;
            _inputHandler = inputHandler;
        }
        
        public State State
        {
            set
            {
                _state = value;
                OnStateChanged?.Invoke(_state);
            }
        }

        private void OnEnable()
        {
            OnStateChanged += StateChangeHandler;
        }

        private void StateChangeHandler(State state)
        {
            switch (state)
            {
                case State.RUN:
                    _playerAnimation.SetPushingAnimation(false);
                    _playerMovement.MovementSpeed = 5f;
                    break;
                case State.PUSH:
                    _playerWeight.StartLoseWeight();            
                    _playerMovement.MovementSpeed = 2f;         
                    _playerAnimation.SetPushingAnimation(true); 
                    break;
                case State.LOSE:
                    EndGameHandler();
                    break;
                case State.WIN:
                    EndGameHandler();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void EndGameHandler()
        {
            _playerMovement.MovementSpeed = 0f;
            _playerMovement.enabled = false;
            _playerWeight.enabled = false;
            _inputHandler.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            OnStateChanged -= StateChangeHandler;
        }
    }
}

public enum State
{
    RUN, PUSH, LOSE, WIN
}