using UnityEngine;

namespace Week_9_Platformer
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotationSpeed;

        private void Update()
        {
            transform.Rotate(_rotationSpeed * Time.deltaTime);
        }
    }
}