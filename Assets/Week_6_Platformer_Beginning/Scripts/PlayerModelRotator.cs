using UnityEngine;

namespace Week_6_Platformer_Beginning
{
    public class PlayerModelRotator : MonoBehaviour
    {
        [SerializeField] private GameObject _aim;
        [SerializeField] private float _limitAngle;
        [SerializeField] private float _rotationSpeed;

        private Quaternion _targetRotation;

        private void Update()
        {
            var angle = _aim.transform.position.x - transform.position.x;

            if (angle > 0)
                _targetRotation = Quaternion.Euler(transform.rotation.x, -_limitAngle, transform.rotation.z);
            else
                _targetRotation = Quaternion.Euler(transform.rotation.x, _limitAngle, transform.rotation.z);

            transform.rotation =
                Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}