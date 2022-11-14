using UnityEngine;

namespace Week_10_Platformer
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ParticleSystem _effectPrefab;
        [SerializeField] [Min(0)] private int _damage = 1;

        public Rigidbody Rigidbody => _rigidbody;
        public int Damage => _damage;

        private void Start()
        {
            Destroy(gameObject, 4f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Die();
        }

        public void Die()
        {
            Instantiate(_effectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}