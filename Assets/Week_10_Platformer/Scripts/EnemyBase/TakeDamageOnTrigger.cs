using UnityEngine;

namespace Week_10_Platformer
{
    public class TakeDamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private bool _isDieOnAnyCollision;

        private void OnTriggerEnter(Collider other)
        {
            if(_isDieOnAnyCollision && other.isTrigger == false) _enemyHealth.TakeDamage(10000);
            
            if(other.attachedRigidbody == null) return;
            
            var bullet = other.attachedRigidbody.GetComponent<Bullet>();

            if (bullet)
            {
                _enemyHealth.TakeDamage(bullet.Damage);
                bullet.Die();
            }
        }
    }
}