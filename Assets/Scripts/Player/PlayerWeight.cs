using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace PlayerController.Weight
{
    public class PlayerWeight : MonoBehaviour
    {
        public event Action OnWeightChanged; 
        
        private Vector3 _weight;
        private const float MinimumWeight = 1.2f;
        private const float MaximumWeight = 1.65f;
        
        private PlayerCollision _playerCollision;
        private PlayerState _playerState;
        
        public Vector3 Weight => _weight;

        [Inject]
        private void Construct(PlayerCollision playerCollision, PlayerState playerState)
        {
            _playerCollision = playerCollision;
            _playerState = playerState;
        }

        private void Awake() => _weight = transform.localScale;

        public void StartGainWeight(Vector3 calories)
        {
            if (_weight.x < MaximumWeight)
            {
                _weight += calories;
                _weight.ClampCoordinates(MinimumWeight, MaximumWeight);
                
                OnWeightChanged?.Invoke();
            }

            StartCoroutine(GainWeight());
        }
        public void StartLoseWeight() => StartCoroutine(LoseWeight());

        private IEnumerator LoseWeight()
        {
            while (_playerCollision.IsPushing)
            {
                _weight -= new Vector3(0.15f, 0.15f, 0.15f);
                OnWeightChanged?.Invoke();

                var localScale = transform.localScale;
                localScale = Vector3.Lerp(localScale, _weight, 2f * Time.deltaTime);

                transform.localScale = localScale;

                if (transform.localScale.x <= MinimumWeight)
                {
                    _playerCollision.IsPushing = false;
                    Lose();
                    yield break;
                }
                
                yield return new WaitForSeconds(0.1f);
            }
            
        }

        private IEnumerator GainWeight()
        {
            var localScale = transform.localScale;

            while (localScale.x < _weight.x)
            {
                localScale = Vector3.Lerp(localScale, _weight, 8f * Time.deltaTime);
                transform.localScale = localScale;

                yield return null;
            }
        }

        private void Lose() => _playerState.State = State.LOSE;
    }
}