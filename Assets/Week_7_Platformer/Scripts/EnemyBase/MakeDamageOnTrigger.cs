using UnityEngine;

namespace Week_7_Platformer
{
    public class MakeDamageOnTrigger : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _damageValue = 1;

        private void OnTriggerEnter(Collider other)
        {
            var playerHealth = other.GetComponentInParent<PlayerHealth>();

            if (playerHealth) playerHealth.TakeDamage(_damageValue);
        }
    }
}