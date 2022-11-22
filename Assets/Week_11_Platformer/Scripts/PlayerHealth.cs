using UnityEngine;
using UnityEngine.Events;

namespace Week_11_Platformer
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private AudioSource _addHealthSound;
        [SerializeField] private HealthUI _healthUI;
        [SerializeField] private int _value;
        [SerializeField] private int _maxValue = 5;

        private bool _invulnerable;

        public UnityEvent DamageTaken;
        public UnityEvent Died;

        private void Start()
        {
            _healthUI.Setup(_maxValue);
            _healthUI.DisplayHealth(_value);
        }

        public void TakeDamage(int damageValue)
        {
            if (_invulnerable == false)
            {
                _value -= damageValue;
                if (_value <= 0)
                {
                    _value = 0;
                    _healthUI.DisplayHealth(_value);
                    _invulnerable = true;
                    Died?.Invoke();
                    return;
                }

                _invulnerable = true;
                Invoke(nameof(StopInvulnerable), 1f);
                _healthUI.DisplayHealth(_value);
                DamageTaken?.Invoke();
            }
        }

        private void StopInvulnerable()
        {
            _invulnerable = false;
        }

        public void AddHealth(int value)
        {
            _value += value;
            if (_value > _maxValue)
                _value = _maxValue;
            _addHealthSound.Play();
            _healthUI.DisplayHealth(_value);
        }
    }
}