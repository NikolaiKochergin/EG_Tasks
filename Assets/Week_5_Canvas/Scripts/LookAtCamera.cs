using UnityEngine;

namespace Week_5_Canvas
{
    public class LookAtCamera : MonoBehaviour
    {
        private void Start()
        {
            if (Camera.main != null) transform.LookAt(Camera.main.transform.position);
        }
    }
}