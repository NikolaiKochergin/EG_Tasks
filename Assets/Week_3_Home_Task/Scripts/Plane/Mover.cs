using UnityEngine;

namespace Week_3_HomeTask_Plane
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerInput))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        private PlayerInput _playerInput;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            var dot = Vector3.Dot(-transform.up, _playerInput.NormalizedDirection);
            transform.Rotate(_rotationSpeed * dot * Time.deltaTime, 0, 0);
        }

        private void FixedUpdate()
        {
            _rigidbody.AddRelativeForce(0f,0f, _speed);
        }
    }
}