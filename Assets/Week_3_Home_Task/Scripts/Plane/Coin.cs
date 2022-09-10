using UnityEngine;

namespace Week_3_HomeTask_Plane
{
    [SelectionBase]
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _destroyDistance;
        private CoinCounter _coinCounter;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<Mover>().transform;
            _coinCounter = FindObjectOfType<CoinCounter>();
            _coinCounter.AddCoin();
        }

        private void Update()
        {
            transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);

            if (_playerTransform == null)
                return;

            var distance = Vector3.Distance(transform.position, _playerTransform.position);
            if (distance < _destroyDistance)
            {
                _coinCounter.RemoveCoin();
                Destroy(gameObject);
            }
        }
    }
}