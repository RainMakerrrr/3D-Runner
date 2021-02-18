using UnityEngine;

public static class MethodExtensions
{
       public static void ClampCoordinates(this Vector3 target, float minimumValue, float maximumValue)
       {
              target.x = Mathf.Clamp(target.x, minimumValue, maximumValue);
              target.y = Mathf.Clamp(target.y, minimumValue, maximumValue);
              target.z = Mathf.Clamp(target.z, minimumValue, maximumValue);
       }

       public static Vector3 ScreenToWorld(this Camera camera, Vector3 position)
       {
              position.z = camera.nearClipPlane;
              return camera.ScreenToWorldPoint(position);
       }
       
}
