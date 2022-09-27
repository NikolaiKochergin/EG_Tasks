using UnityEngine;

namespace Week_6_Platformer_Beginning
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