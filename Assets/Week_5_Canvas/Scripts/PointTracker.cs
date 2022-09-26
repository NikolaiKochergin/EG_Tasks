using UnityEngine;

namespace Week_5_Canvas
{
    public class PointTracker : MonoBehaviour
    {
        [SerializeField] private Transform _targetPoint;

        private void Update()
        {
            transform.position = _targetPoint.position;
            transform.rotation = _targetPoint.rotation;
        }
    }
}