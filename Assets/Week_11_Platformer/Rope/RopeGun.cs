using UnityEngine;

namespace Week_11_Platformer
{
    public enum RopeState
    {
        Disabled,
        Fly,
        Active
    }

    public class RopeGun : MonoBehaviour
    {
        [SerializeField] private Hook _hook;
        [SerializeField] private Transform _spawn;
        [SerializeField] private Transform _ropeStart;
        [SerializeField] private RopeRenderer _ropeRenderer;
        [SerializeField] private PlayerMove _playerMove;
        [SerializeField] [Min(0)] private float _speed;
        [SerializeField] [Min(0)] private float _maxRopeLength = 20f;


        private RopeState _currentRopeState;
        private float _length;
        private SpringJoint _springJoint;


        private void Update()
        {
            if (Input.GetMouseButtonDown(2))
                Shot();
            if (_currentRopeState == RopeState.Fly)
            {
                var distance = Vector3.Distance(_ropeStart.position, _hook.transform.position);
                if (distance > _maxRopeLength)
                {
                    _hook.gameObject.SetActive(false);
                    _currentRopeState = RopeState.Disabled;
                    _ropeRenderer.Hide();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_currentRopeState == RopeState.Active && _playerMove.IsGrounded == false)
                    _playerMove.Jump();
                DestroySpring();
            }

            if (_currentRopeState == RopeState.Fly || _currentRopeState == RopeState.Active)
                _ropeRenderer.Draw(_ropeStart.position, _hook.transform.position, _length);
        }

        private void Shot()
        {
            _length = 1f;

            if (_springJoint)
                Destroy(_springJoint);

            _hook.gameObject.SetActive(true);
            _hook.StopFix();
            _hook.transform.position = _spawn.position;
            _hook.transform.rotation = _spawn.rotation;
            _hook.Rigidbody.velocity = _spawn.forward * _speed;

            _currentRopeState = RopeState.Fly;
        }

        public void CreateSpring()
        {
            if (_springJoint == null)
            {
                _springJoint = gameObject.AddComponent<SpringJoint>();
                _springJoint.connectedBody = _hook.Rigidbody;
                _springJoint.anchor = _ropeStart.localPosition;
                _springJoint.autoConfigureConnectedAnchor = false;
                _springJoint.connectedAnchor = Vector3.zero;
                _springJoint.spring = 100f;
                _springJoint.damper = 5f;

                _length = Vector3.Distance(_ropeStart.position, _hook.transform.position);
                _springJoint.maxDistance = _length;

                _currentRopeState = RopeState.Active;
            }
        }

        public void DestroySpring()
        {
            if (_springJoint)
            {
                Destroy(_springJoint);
                _currentRopeState = RopeState.Disabled;
                _hook.gameObject.SetActive(false);
                _ropeRenderer.Hide();
            }
        }
    }
}