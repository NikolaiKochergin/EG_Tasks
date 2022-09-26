using UnityEngine;
using UnityEngine.UI;

namespace Week_5_Canvas
{
    public class BodyPart : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private void Start()
        {
            _slider.value = transform.localScale.x;
        }

        public void SetScale(float value)
        {
            transform.localScale = new Vector3(value, value, value);
        }
    }
}