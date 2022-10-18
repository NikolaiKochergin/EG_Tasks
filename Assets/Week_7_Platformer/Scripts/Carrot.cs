using UnityEngine;

namespace Week_8_Platformer
{
    public class Carrot : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] [Min(0)] private float _speed = 5;

        private void Start()
        {
            var playerTransform = FindObjectOfType<Head>().transform;
            var toPlayer = (playerTransform.position - transform.position).normalized;

            _rigidbody.velocity = toPlayer * _speed;
        }
    }
}