using UnityEngine;

namespace Week_10_Platformer
{
    public class RayGizmo : MonoBehaviour
    {
        private void OnDrawGizmosSelected()

        {
            var ray = new Ray(transform.position, transform.forward);

            Gizmos.DrawRay(ray);
        }
    }
}