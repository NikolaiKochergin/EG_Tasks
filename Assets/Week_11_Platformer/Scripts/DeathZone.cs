using UnityEngine;

namespace Week_11_Platformer
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField]private BoxCollider _collider;
        
        private void OnTriggerEnter(Collider other)
        {
            var player = other.attachedRigidbody?.GetComponent<PlayerDeactivator>();
        
            if(player)
                gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if(!_collider)
                return;

            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
}