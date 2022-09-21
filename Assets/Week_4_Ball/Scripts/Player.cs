using UnityEngine;

namespace Week_4_HomeTask_Ball
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public Rigidbody Rigidbody => _rigidbody;
        
        private void OnTriggerEnter(Collider other)
        {
            var coin = other.GetComponent<Coin>();
            if (coin) coin.Destroy();
        }
    }
}