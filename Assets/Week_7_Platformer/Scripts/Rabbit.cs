using UnityEngine;

namespace Week_7_Platformer
{
    public class Rabbit : MonoBehaviour
    {
        private const string Attack = nameof(Attack);
        
        [SerializeField] private Animator _animator;
        [SerializeField] private float _attackPeriod = 7f;

        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > _attackPeriod)
            {
                _timer = 0;
                _animator.SetTrigger(Attack);
            }
        }
    }
}