using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Week_7_Platformer
{
    public class DamageScreen : MonoBehaviour
    {
        [SerializeField] private Image _damageImage;
        [SerializeField] private float _effectDuration;

        public void StartEffect()
        {
            StartCoroutine(ShowEffect());
        }

        private IEnumerator ShowEffect()
        {
            _damageImage.enabled = true;
            for (float t = 1; t > 0; t -= Time.deltaTime / _effectDuration)
            {
                _damageImage.color = new Color(1, 0, 0, t);

                yield return null;
            }

            _damageImage.enabled = false;
        }
    }
}