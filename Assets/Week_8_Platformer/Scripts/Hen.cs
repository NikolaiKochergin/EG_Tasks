using UnityEngine;

namespace Week_8_Platformer
{
    public class Hen : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] [Min(0)] private float _speed = 3f;
        [SerializeField] [Min(0)] private float _timeToReachSpeed = 1;
        
        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<Head>().transform;
        }

        private void FixedUpdate()
        {
            var toPlayer = (_playerTransform.position - transform.position).normalized;
            Vector3 force = _rigidbody.mass * (toPlayer * _speed - _rigidbody.velocity) / _timeToReachSpeed;
            
            _rigidbody.AddForce(force);
        }
    }
}