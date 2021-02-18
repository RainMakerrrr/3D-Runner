using Obstacles;
using UnityEngine;

namespace PlayerController
{
    public class PlayerCollision : MonoBehaviour
    {
        private ICollision _collision;
        
        public bool IsPushing { get; set; }
        private int _collisionCount;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<Wall>() && _collisionCount < 1)
            {
                IsPushing = true;
                _collisionCount++;
            }

            var collision = other.gameObject.GetComponent<ICollision>();
            if (collision == null) return;

            _collision = collision;
            
            _collision.Collide();
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.GetComponent<Wall>())
            {
                IsPushing = false;
                _collisionCount = 0;
            }
            
            var collision = other.gameObject.GetComponent<ICollision>();
            if (_collision != collision) return;

            _collision = null;
        }
    }
}