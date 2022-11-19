using UnityEngine;

namespace Week_11_Platformer
{
    public class RopeRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] [Min(1)] private int _segments = 10;

        public void Draw(Vector3 a, Vector3 b, float length)
        {
            _lineRenderer.enabled = true;
            
            var interpolant = Vector3.Distance(a, b) / length;
            var offset = Mathf.Lerp(length / 2f, 0f, interpolant);

            var aDown = a + Vector3.down * offset;
            var bDown = b + Vector3.down * offset;

            _lineRenderer.positionCount = _segments + 1;
            for (var i = 0; i < _segments + 1; i++)
                _lineRenderer.SetPosition(i,
                    Bezier.GetPoint(a, aDown, bDown, b,
                        (float) i / _segments));
        }

        public void Hide()
        {
            _lineRenderer.enabled = false;
        }
    }
}