using UnityEngine;

namespace Week_11_Platformer
{
    public class PlayerMove : MonoBehaviour
    {
        private const string Horizontal = nameof(Horizontal);

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] [Min(0)] private float _moveForce;
        [SerializeField] [Min(0)] private float _jumpForce;
        [SerializeField] [Min(0)] private float _friction;
        [SerializeField] [Range(0f, 180f)] private float _groundedAngle = 45f;
        [SerializeField] [Min(0)] private float _jumpMoveFactor = 0.1f;
        [SerializeField] [Min(0)] private float _maxSpeed;
        [SerializeField] private Transform _colliderTransform;
        [SerializeField] [Min(0)] private float _crouchDuration = 15f;
        [SerializeField] [Min(0)] private float _jampTorque = 15f;
        [SerializeField] [Min(0)] private float _returnToIdentitySpeed = 15f;
        [SerializeField] private PlayerModelRotator _playerModelRotator;

        public bool IsGrounded { get; private set; }

        private int _jumpFrameCounter;

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || IsGrounded == false)
                _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 0.5f, 1f),
                    Time.deltaTime * _crouchDuration);
            else
                _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, Vector3.one,
                    Time.deltaTime * _crouchDuration);

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
                Jump();
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(Vector3.zero, ForceMode.VelocityChange);
            
            var speedMultiplier = 1f;

            if (IsGrounded == false)
            {
                speedMultiplier = _jumpMoveFactor;
                if (_rigidbody.velocity.x < -_maxSpeed && Input.GetAxis(Horizontal) < 0)
                    speedMultiplier = 0f;
                if (_rigidbody.velocity.x > _maxSpeed && Input.GetAxis(Horizontal) > 0)
                    speedMultiplier = 0f;
            }

            _rigidbody.AddForce(Input.GetAxis(Horizontal) * _moveForce * speedMultiplier, 0, 0,
                ForceMode.VelocityChange);

            if (IsGrounded)
            {
                _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity,
                    _returnToIdentitySpeed * Time.deltaTime);
                
                _playerModelRotator.enabled = true;
            }

            _jumpFrameCounter += 1;
            if (_jumpFrameCounter == 2)
            {
                _playerModelRotator.enabled = false;
                _rigidbody.freezeRotation = false;
                _rigidbody.AddRelativeTorque(Vector3.forward * _jampTorque, ForceMode.VelocityChange);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            IsGrounded = false;
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            foreach (var contact in collisionInfo.contacts)
            {
                var angle = Vector3.Angle(contact.normal, Vector3.up);
                if (angle < _groundedAngle)
                {
                    IsGrounded = true;
                    _rigidbody.freezeRotation = true;
                }
            }
        }

        public void Jump()
        {
            _rigidbody.AddForce(0, _jumpForce, 0, ForceMode.VelocityChange);
            _jumpFrameCounter = 0;
        }
    }
}