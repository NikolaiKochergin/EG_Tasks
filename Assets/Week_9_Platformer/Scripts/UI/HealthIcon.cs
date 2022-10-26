using UnityEngine;

namespace Week_9_Platformer
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