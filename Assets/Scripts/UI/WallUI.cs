using Obstacles;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class WallUI : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _wallStrength;
        private Wall _wall;

        [Inject]
        private void Construct(Wall wall)
        {
            _wall = wall;
        }

        private void Start()
        {
            _wallStrength.text = _wall.Strength.ToString();
            _wall.OnStrengthChanged += WallStrengthChangedHandler;
        }
        
        private void WallStrengthChangedHandler()
        {
            _wallStrength.text = _wall.Strength.ToString();
        }

        private void OnDisable()
        {
            _wall.OnStrengthChanged -= WallStrengthChangedHandler;
        }
    }
}