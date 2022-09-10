using UnityEngine;

namespace Week_3_HomeTask_Plane
{
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 _currentMousePosition;
        private Vector3 _startMousePosition;
        public Vector3 NormalizedDirection { get; private set; }

        private void Awake()
        {
            NormalizedDirection = transform.forward;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _startMousePosition = Input.mousePosition;

            if (Input.GetMouseButton(0))
            {
                _currentMousePosition = Input.mousePosition;
                NormalizedDirection = (_currentMousePosition - _startMousePosition).normalized;
            }
        }
    }
}