using UnityEngine;

namespace Week_7_Platformer
{
    public class TakeDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private bool _isDieOnAnyCollision;

        private void OnCollisionEnter(Collision collision)
        {
            if (_isDieOnAnyCollision) _enemyHealth.TakeDamage(10000);
            
            if (collision.rigidbody == null) return;

            var bullet = collision.rigidbody.GetComponent<Bullet>();

            if (bullet) _enemyHealth.TakeDamage(1);

        }
    }
}