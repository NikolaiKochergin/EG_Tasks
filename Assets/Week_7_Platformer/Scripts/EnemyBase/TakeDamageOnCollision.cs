using UnityEngine;

namespace Week_7_Platformer
{
    public class TakeDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.rigidbody == null) return;
            
            var bullet = collision.rigidbody.GetComponent<Bullet>();

            if (bullet) _enemyHealth.TakeDamage(1);
        }
    }
}