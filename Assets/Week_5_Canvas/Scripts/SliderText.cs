using UnityEngine;
using UnityEngine.UI;

namespace Week_5_Canvas
{
    public class SliderText : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void ShowValue(float value)
        {
            _text.text = value.ToString("0.0");
        }
    }
}
