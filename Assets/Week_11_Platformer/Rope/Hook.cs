using UnityEngine;

namespace Week_11_Platformer
{
    public class Hook : MonoBehaviour
    {
        [SerializeField] private Collider[] _borderColliders;
        [SerializeField] private Collider _collider;
        [SerializeField] private Collider _playerCollider;
        [SerializeField] private RopeGun _ropeGun;

        private FixedJoint _fixedJoint;

        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

        private void Start()
        {
            Physics.IgnoreCollision(_collider, _playerCollider);
            foreach (var collider in _borderColliders)
                Physics.IgnoreCollision(_collider, collider);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_fixedJoint == null)
            {
                _fixedJoint = gameObject.AddComponent<FixedJoint>();
                if (collision.rigidbody)
                    _fixedJoint.connectedBody = collision.rigidbody;
                
                _ropeGun.CreateSpring();
            }
        }

        public void StopFix()
        {
            if (_fixedJoint)
                Destroy(_fixedJoint);
        }
    }
}