using UnityEngine;
using UnityEngine.UI;

namespace Week_5_Canvas
{
    public class PlayerText : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}
