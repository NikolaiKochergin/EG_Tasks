using UnityEngine;

namespace Week_7_Platformer
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _value;

        public void TakeDamage(int damageValue)
        {
            _value -= damageValue;
            if (_value <= 0) Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}