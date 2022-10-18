using UnityEngine;

namespace Week_8_Platformer
{
    public class MakeDamageOnTrigger : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _damageValue = 1;

        private void OnTriggerEnter(Collider other)
        {
            if(other.attachedRigidbody == null) return;
            
            var playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();

            if (playerHealth) playerHealth.TakeDamage(_damageValue);
        }
    }
}