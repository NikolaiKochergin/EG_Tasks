using UnityEngine;

namespace Week_7_Platformer
{
    public class TakeDamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;

        private void OnTriggerEnter(Collider other)
        {
            var bullet = other.GetComponentInParent<Bullet>();

            if (bullet) _enemyHealth.TakeDamage(bullet.Damage);
        }
    }
}