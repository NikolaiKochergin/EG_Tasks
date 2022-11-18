using UnityEngine;

namespace Week_11_Platformer
{
    public class RotateToTargetEuler : MonoBehaviour
    {
        [SerializeField] private Vector3 _leftEuler;
        [SerializeField] private Vector3 _rightEuler;
        [SerializeField] [Min(0)] private float _rotationSpeed;

        private Vector3 _targetEuler;

        private void Update()
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler), _rotationSpeed * Time.deltaTime);
        }

        public void RotateLeft()
        {
            _targetEuler = _leftEuler;
        }

        public void RotateRight()
        {
            _targetEuler = _rightEuler;
        }
    }
}