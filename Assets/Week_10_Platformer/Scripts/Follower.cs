using UnityEngine;

namespace Week_10_Platformer
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _followRate;

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _followRate);
        }
    }
}