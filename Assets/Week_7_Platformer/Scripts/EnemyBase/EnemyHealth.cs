using UnityEngine;
using UnityEngine.Events;

namespace Week_7_Platformer
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _value = 1;

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