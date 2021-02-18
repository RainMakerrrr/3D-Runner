using UnityEngine;

namespace PlayerController.Movement
{
    public class Track : MonoBehaviour
    {
        [SerializeField] private int _order;
        [SerializeField] private Transform _trackPosition;
        public int Order => _order;
        public Transform TrackPosition => _trackPosition;
        
    }
}