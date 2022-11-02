using UnityEngine;

namespace Week_9_Platformer
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] [Min(0)] private float _bulletSpeed = 10f;
        [SerializeField] [Min(0)] private float _shotPeriod = 0.2f;
        [SerializeField] private AudioSource _shotSound;
        [SerializeField] private GameObject _flash;

        private float _timer;

        private void Update()
        {
            _timer += Time.unscaledDeltaTime;

            if (_timer > _shotPeriod && Input.GetMouseButton(0))
            {
                _timer = 0;
                Shot();
            }
        }

        public virtual void Shot()
        {
            var newBullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            newBullet.Rigidbody.velocity = _bulletSpawnPoint.forward * _bulletSpeed;
            _shotSound.Play();
            _flash.SetActive(true);
            Invoke(nameof(HideFlash), 0.12f);
        }

        private void HideFlash()
        {
            _flash.SetActive(false);
        }

        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }
        
        public virtual void AddBullets(int numberOfBullets){}
    }
}