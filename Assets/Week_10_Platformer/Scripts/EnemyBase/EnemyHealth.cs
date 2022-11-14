using UnityEngine;
using UnityEngine.Events;

namespace Week_10_Platformer
{
    [SelectionBase]
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _value = 1;

        public UnityEvent DamageTaken;
        public UnityEvent Died;

        public void TakeDamage(int damageValue)
        {
            _value -= damageValue;
            if (_value <= 0)
            {
                Die();
                return;
            }
            DamageTaken?.Invoke();
        }

        private void Die()
        {
            Died?.Invoke();
        }
    }
}