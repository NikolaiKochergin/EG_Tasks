using UnityEngine;

namespace Week_7_Platformer
{
    public class LootHeal : MonoBehaviour
    {
        [SerializeField] private int _healthValue = 1;

        private void OnTriggerEnter(Collider other)
        {
            var playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();

            if (playerHealth)
            {
                playerHealth.AddHealth(_healthValue);
                Destroy(gameObject);
            }
        }
    }
}