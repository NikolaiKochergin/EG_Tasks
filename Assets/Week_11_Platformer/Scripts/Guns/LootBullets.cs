using UnityEngine;

namespace Week_11_Platformer
{
    public class LootBullets : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _gunIndex;
        [SerializeField] [Min(0)] private int _numberOfBullets;

        private void OnTriggerEnter(Collider other)
        {
            var playerArmory = other.attachedRigidbody.GetComponent<PlayerArmory>();

            if (playerArmory)
            {
                playerArmory.AddBullets(_gunIndex, _numberOfBullets);
                Destroy(gameObject);
            }
        }
    }
}