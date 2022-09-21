using UnityEngine;

namespace Week_4_HomeTask_Ball
{
    public class PlayerTracker : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private void Update()
        {
            transform.position = _player.transform.position;
        }
    }
}