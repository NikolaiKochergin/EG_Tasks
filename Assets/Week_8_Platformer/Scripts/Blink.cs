using System.Collections;
using UnityEngine;

namespace Week_8_Platformer
{
    public class Blink : MonoBehaviour
    {
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

        [SerializeField] private Renderer[] _renderers;
        [SerializeField] [Min(0)] private float _duration = 1;
        [SerializeField] [Min(0)] private float _friquency = 30;

        public void StartBlink()
        {
            StartCoroutine(BlinkEffect());
        }

        private IEnumerator BlinkEffect()
        {
            for (float t = 0; t < 1; t += Time.deltaTime / _duration)
            {
                foreach (var renderer in _renderers)
                foreach (var material in renderer.materials)
                    material.SetColor(EmissionColor,
                        new Color(Mathf.Sin(t * _friquency) * 0.5f + 0.5f, 0, 0, 0));

                yield return null;
            }
        }
    }
}