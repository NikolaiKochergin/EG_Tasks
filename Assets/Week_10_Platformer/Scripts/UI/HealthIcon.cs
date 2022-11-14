using UnityEngine;

namespace Week_10_Platformer
{
    public class HealthIcon : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}