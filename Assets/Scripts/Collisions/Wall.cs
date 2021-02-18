using System;
using System.Collections;
using PlayerController;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class Wall : MonoBehaviour, ICollision
    {
        [SerializeField] private int _minimumStrength;
        [SerializeField] private int _maximumStrength;
        
        public event Action OnStrengthChanged;
        
        private int _strength;
        private Rigidbody _rigidbody;
        private MeshRenderer _meshRenderer;
        private PlayerState _playerState;
        
        public int Strength => _strength;

        [Inject]
        private void Construct(Rigidbody rigidbody,MeshRenderer meshRenderer, PlayerState playerState)
        {
            _rigidbody = rigidbody;
            _meshRenderer = meshRenderer;
            _playerState = playerState; ;
        }

        private void Awake()
        {
            _strength = Random.Range(_minimumStrength, _maximumStrength);
        }

        private IEnumerator LoseWallStrength()
        {
            while (_strength > 0)
            {
                _strength--;
                OnStrengthChanged?.Invoke();

                _rigidbody.velocity = _playerState.transform.forward * 2f;
                
                yield return new WaitForSeconds(0.1f);
            }

            StartCoroutine(ChangeWallTransparency());
            GetComponent<BoxCollider>().isTrigger = true;

            _playerState.State = State.RUN;
        }

        private IEnumerator ChangeWallTransparency()
        {
            var wallColor = _meshRenderer.material.color;
            wallColor.a = 0f;

            while (_meshRenderer.material.color.a >= 0)
            {
                _meshRenderer.material.color =
                    Color.Lerp(_meshRenderer.material.color, wallColor, 2f * Time.deltaTime);
                yield return null;
            }
        }
        
     
        
        public void Collide()
        {
            _playerState.State = State.PUSH;
            StartCoroutine(LoseWallStrength());
        }
    }
}