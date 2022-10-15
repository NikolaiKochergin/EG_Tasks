using System.Collections.Generic;
using UnityEngine;

namespace Week_7_Platformer
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private HealthIcon _healthIconPrefab;

        private readonly List<HealthIcon> _healthIcons = new();

        public void Setup(int maxHealth)
        {
            for (var i = 0; i < maxHealth; i++)
            {
                var newIcon = Instantiate(_healthIconPrefab, transform);
                _healthIcons.Add(newIcon);
            }
        }

        public void DisplayHealth(int value)
        {
            for (var i = 0; i < _healthIcons.Count; i++)
                if (i < value)
                    _healthIcons[i].Show();
                else
                    _healthIcons[i].Hide();
        }
    }
}