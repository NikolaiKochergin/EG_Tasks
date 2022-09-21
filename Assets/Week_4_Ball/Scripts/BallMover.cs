using UnityEngine;

namespace Week_4_HomeTask_Ball
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallMover : MonoBehaviour
    {
        [SerializeField] private Transform _cameraContainer;
        [SerializeField] private float _torqueValue;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.maxAngularVelocity = 500f;
        }

        private void FixedUpdate()
        {
            _rigidbody.AddTorque(_cameraContainer.right * Input.GetAxis("Vertical") * _torqueValue);
            _rigidbody.AddTorque(-_cameraContainer.forward * Input.GetAxis("Horizontal") * _torqueValue);
        }
    }
}