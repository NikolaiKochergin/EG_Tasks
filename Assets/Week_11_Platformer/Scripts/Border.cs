using UnityEngine;

namespace Week_11_Platformer.Scripts
{
    public class Border : MonoBehaviour
    {
        [SerializeField] private BoxCollider _collider;

        private void OnDrawGizmos()
        {
            if (!_collider)
                return;

            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
}