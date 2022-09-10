using System;
using TMPro;
using UnityEngine;

namespace Week_3_HomeTask_Plane
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lossText;
        [SerializeField] private int _health;

        private void Awake()
        {
            _lossText.gameObject.SetActive(false);
        }

        public void TakeDamage(int value)
        {
            _health -= value;
            if (_health <= 0)
            {
                _lossText.gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}