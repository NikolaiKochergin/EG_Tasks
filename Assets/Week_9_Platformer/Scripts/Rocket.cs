using UnityEngine;

namespace Week_9_Platformer
{
    public class Rocket : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float _speed = 5;
        [SerializeField] [Min(0)] private float _rotationSpeed = 3;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMove>().transform;
        }

        private void Update()
        {
            transform.position += Time.deltaTime * transform.forward * _speed;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            var toPlayer = _playerTransform.position - transform.position;
            var targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}