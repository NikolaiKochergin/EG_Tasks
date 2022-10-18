using UnityEngine;

namespace Week_8_Platformer
{
    public class Head : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void Update()
        {
            transform.position = _target.position;
        }
    }
}