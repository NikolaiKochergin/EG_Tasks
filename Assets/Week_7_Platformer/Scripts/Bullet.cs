using UnityEngine;

namespace Week_7_Platformer
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ParticleSystem _effectPrefab;

        public Rigidbody Rigidbody => _rigidbody;

        private void Start()
        {
            Destroy(gameObject, 4f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Instantiate(_effectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}