using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Week_9_Platformer
{
    public class EnemyContainer : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float _activationDistance;

        private List<EnemyHealth> _enemies;
        private Transform _player;

        private void Start()
        {
            _enemies = GetComponentsInChildren<EnemyHealth>().ToList();
            _player = FindObjectOfType<PlayerHealth>().transform;
        }

        private void FixedUpdate()
        {
            foreach (var enemy in _enemies)
            {
                if (enemy == null)
                {
                    _enemies.Remove(enemy);
                    
                    if(_enemies.Count == 0)
                        Debug.Log("You win");
                    
                    return;
                }
                
                var toPlayer = Vector3.Distance(enemy.transform.position, _player.position);

                enemy.gameObject.SetActive(toPlayer < _activationDistance);
            }
        }
    }
}