using System.Collections;
using UnityEngine;

namespace Week_5_Canvas
{
    public class SnowManMover : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField] [Min(0.1f)] private float _jumpDuration;

        private Coroutine _jumpCoroutine;

        public void Jump()
        {
            _jumpCoroutine ??= StartCoroutine(ShowJump());
        }

        private IEnumerator ShowJump()
        {
            var starPosition = transform.position;

            for (float i = 0; i < 1; i += Time.deltaTime / _jumpDuration)
            {
                transform.position = starPosition + new Vector3(0, _jumpCurve.Evaluate(i), 0);

                yield return null;
            }

            transform.position = starPosition;
            _jumpCoroutine = null;
        }
    }
}