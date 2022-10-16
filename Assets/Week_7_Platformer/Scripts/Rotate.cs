using UnityEngine;

namespace Week_7_Platformer
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