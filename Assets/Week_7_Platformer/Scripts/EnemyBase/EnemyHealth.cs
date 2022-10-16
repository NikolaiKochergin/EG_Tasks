using UnityEngine;
using UnityEngine.Events;

namespace Week_7_Platformer
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _value;

        public UnityEvent DamageTaken;
        
        public void TakeDamage(int damageValue)
        {
            _value -= damageValue;
            if (_value <= 0) Die();
            DamageTaken?.Invoke();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}