using System.Collections;
using PlayerController;
using PlayerController.Weight;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class WeightUI : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        private PlayerWeight _playerWeight;
        private PlayerCollision _playerCollision;

        [Inject]
        private void Construct(PlayerWeight playerWeight, PlayerCollision playerCollision)
        {
            _playerWeight = playerWeight;
            _playerCollision = playerCollision;
        }

        private void Start()
        {
            _slider.maxValue = _playerWeight.Weight.x;
            _slider.value = _slider.maxValue;
            
            _slider.gameObject.SetActive(false);
            
            _playerWeight.OnWeightChanged += WeightChangeHandler;
        }

        private void WeightChangeHandler()
        {
            _slider.gameObject.SetActive(true);
            _slider.value = _playerWeight.Weight.x;
            StartCoroutine(TurnOffSlider());
        }

        private IEnumerator TurnOffSlider()
        {
            while (_playerCollision.IsPushing) yield return null;
            
            yield return new WaitForSeconds(0.5f);
            _slider.gameObject.SetActive(false);
        }
        
        private void OnDisable() => _playerWeight.OnWeightChanged -= WeightChangeHandler;
    }
}