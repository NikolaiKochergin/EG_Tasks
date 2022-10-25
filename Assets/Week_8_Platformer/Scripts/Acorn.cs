using UnityEngine;

namespace Week_8_Platformer
{
    public class Acorn : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Vector3 _velocity;
        [SerializeField] private float _maxRotationSpeed;

        private void Start()
        {
            _rigidbody.AddRelativeForce(_velocity, ForceMode.VelocityChange);
            _rigidbody.angularVelocity = new Vector3(
                Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
                Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
                Random.Range(-_maxRotationSpeed, _maxRotationSpeed)
                );
        }
    }
}