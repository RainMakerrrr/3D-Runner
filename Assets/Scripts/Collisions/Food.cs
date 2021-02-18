using PlayerController.Weight;
using UnityEngine;
using Zenject;


namespace Obstacles.Food
{
    public class Food : MonoBehaviour, ICollision
    {
        [SerializeField] private float _rotateSpeed;
        private float _calories;
        private PlayerWeight _playerWeight;

        [Inject]
        private void Construct(PlayerWeight playerWeight)
        {
            _playerWeight = playerWeight;
        }

        private void Start() => _calories = Random.Range(0.3f, 0.7f);

        private void Update() => transform.Rotate(Vector3.up * _rotateSpeed, Space.World);

        public void Collide()
        {
            _playerWeight.StartGainWeight(new Vector3(_calories,_calories,_calories));
            
            Destroy(gameObject);
        }
    }
}