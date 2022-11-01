using UnityEngine;
using UnityEngine.UI;

namespace Week_9_Platformer
{
    public class Automat : Gun
    {
        [Header("Automat")] 
        [SerializeField] [Min(0)] private int _numberOfBullets = 30;
        [SerializeField] private Text _bulletsText;
        [SerializeField] private PlayerArmory _playerArmory;

        protected override void Shot()
        {
            base.Shot();
            _numberOfBullets -= 1;
            UpdateText();
            if(_numberOfBullets == 0)
                _playerArmory.TakeGunByIndex(0);
        }

        public override void Activate()
        {
            base.Activate();
            _bulletsText.enabled = true;
            UpdateText();
        }

        public override void Deactivate()
        {
            base.Deactivate();
            _bulletsText.enabled = false;
        }

        private void UpdateText()
        {
            _bulletsText.text = "Пули: " + _numberOfBullets;
        }

        public override void AddBullets(int numberOfBullets)
        {
            _numberOfBullets += numberOfBullets;
            UpdateText();
            _playerArmory.TakeGunByIndex(1);
        }
    }
}