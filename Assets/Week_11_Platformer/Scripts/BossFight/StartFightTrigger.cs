using UnityEngine;
using UnityEngine.Events;

namespace Week_11_Platformer
{
    public class StartFightTrigger : MonoBehaviour
    {
        [SerializeField]private BoxCollider _collider;
        
        public UnityEvent OnStartFight;
        
        private void OnTriggerExit(Collider other)
        {
            var player = other.attachedRigidbody?.GetComponent<PlayerMove>();
            
            if(player)
                OnStartFight?.Invoke();
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
