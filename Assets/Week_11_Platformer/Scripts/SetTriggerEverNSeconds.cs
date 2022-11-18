using UnityEngine;

namespace Week_11_Platformer
{
    public class SetTriggerEverNSeconds : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string TriggerName = "Attack";
        
        [SerializeField] private float _period = 7f;

        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > _period)
            {
                _timer = 0;
                _animator.SetTrigger(TriggerName);
            }
        }
    }
}