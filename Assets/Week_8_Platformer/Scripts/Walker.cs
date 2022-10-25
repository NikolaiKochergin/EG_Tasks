using UnityEngine;
using UnityEngine.Events;

namespace Week_8_Platformer
{
    public enum Direction
    {
        Left,
        Right
    }

    public class Walker : MonoBehaviour
    {
        [SerializeField] private Transform _leftTarget;
        [SerializeField] private Transform _rightTarget;
        [SerializeField] [Min(0)] private float _speed;
        [SerializeField] [Min(0)] private float _stopTime;
        [SerializeField] private Direction _currentDirection;

        private bool _isStopped;

        public UnityEvent EventOnLeftTarget;
        public UnityEvent EventOnRightTarget;

        private void Start()
        {
            _leftTarget.parent = null;
            _rightTarget.parent = null;
        }

        private void Update()
        {
            if (_isStopped)
                return;

            if (_currentDirection == Direction.Left)
            {
                transform.position -= new Vector3(Time.deltaTime * _speed, 0f, 0f);
                if (transform.position.x < _leftTarget.position.x)
                {
                    _currentDirection = Direction.Right;
                    _isStopped = true;
                    Invoke(nameof(ContinueWalk), _stopTime);
                    EventOnLeftTarget?.Invoke();
                }
            }
            else
            {
                transform.position += new Vector3(Time.deltaTime * _speed, 0f, 0f);
                if (transform.position.x > _rightTarget.position.x)
                {
                    _currentDirection = Direction.Left;
                    _isStopped = true;
                    Invoke(nameof(ContinueWalk), _stopTime);
                    EventOnRightTarget?.Invoke();
                }
            }
        }

        private void ContinueWalk()
        {
            _isStopped = false;
        }
    }
}