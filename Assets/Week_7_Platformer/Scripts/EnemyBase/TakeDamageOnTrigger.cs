using UnityEngine;

namespace Week_7_Platformer
{
    public class TakeDamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;

        private void OnTriggerEnter(Collider other)
        {
            if(other.attachedRigidbody == null) return;
            
            var bullet = other.attachedRigidbody.GetComponent<Bullet>();

            if (bullet) _enemyHealth.TakeDamage(bullet.Damage);
        }
    }
}