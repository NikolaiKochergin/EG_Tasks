using UnityEngine;

namespace Week_11_Platformer
{
    public class MakeDamageOnCollision : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _damageValue = 1;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.rigidbody == null) return;

            var playerHealth = collision.rigidbody.GetComponent<PlayerHealth>();

            if (playerHealth)
                playerHealth.TakeDamage(_damageValue);
        }
    }
}