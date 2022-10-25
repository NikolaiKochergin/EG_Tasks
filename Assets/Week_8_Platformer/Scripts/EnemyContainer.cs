using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Week_8_Platformer
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

        private void Update()
        {
            foreach (var enemy in _enemies)
            {
                if (enemy == null)
                {
                    _enemies.Remove(enemy);
                    return;
                }
                
                var toPlayer = Vector3.Distance(enemy.transform.position, _player.position);

                enemy.gameObject.SetActive(toPlayer < _activationDistance);
            }
        }
    }
}