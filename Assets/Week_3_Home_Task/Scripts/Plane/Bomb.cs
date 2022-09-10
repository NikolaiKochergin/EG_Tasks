using UnityEngine;

namespace Week_3_HomeTask_Plane
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private int _damage;

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();
            if (player)
            {
                player.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}