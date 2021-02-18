using Obstacles;
using UnityEngine;

namespace Collisions
{
    public class WallDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var wall = other.GetComponent<Wall>();
            if(wall)
                Destroy(wall.gameObject);
        }
    }
}