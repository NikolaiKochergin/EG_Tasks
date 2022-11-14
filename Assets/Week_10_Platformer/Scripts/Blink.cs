using System;
using System.Collections;
using UnityEngine;

namespace Week_10_Platformer
{
    public class Blink : MonoBehaviour
    {
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

        [SerializeField] private Renderer[] _renderers;
        [SerializeField] [Min(0)] private float _duration = 1;
        [SerializeField] [Min(0)] private float _friquency = 30;

        private Coroutine _blinkCoroutine;
        
        public void StartBlink()
        {
            _blinkCoroutine = StartCoroutine(BlinkEffect());
        }

        private void OnDisable()
        {
            if(_blinkCoroutine != null)
                StopCoroutine(_blinkCoroutine);
            SetEmissionColor(0);
        }

        private IEnumerator BlinkEffect()
        {
            for (float t = 0; t < 1; t += Time.deltaTime / _duration)
            {
                SetEmissionColor(Mathf.Sin(t * _friquency) * 0.5f + 0.5f);

                yield return null;
            }
            SetEmissionColor(0f);
        }

        private void SetEmissionColor(float value)
        {
            foreach (var renderer in _renderers)
            foreach (var material in renderer.materials)
                material.SetColor(EmissionColor,
                    new Color(value, 0, 0, 0));
        }
    }
}