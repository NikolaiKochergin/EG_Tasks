using UnityEngine;

namespace Week_6_Platformer_Beginning
{
    public class PlayerMove : MonoBehaviour
    {
        private const string Horizontal = nameof(Horizontal);

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _moveForce;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _friction;

        private bool _isGrounded;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _rigidbody.AddForce(0, _jumpForce, 0, ForceMode.VelocityChange);
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(Input.GetAxis(Horizontal) * _moveForce, 0, 0, ForceMode.VelocityChange);
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
        }
    }
}