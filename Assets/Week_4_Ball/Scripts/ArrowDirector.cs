using UnityEngine;

namespace Week_4_HomeTask_Ball
{
    public class ArrowDirector : MonoBehaviour
    {
        [SerializeField] private CoinManager _coinManager;

        private void Update()
        {
            var coinTransform = FindNearestCoinTransform();
            if (coinTransform == null) return;
            transform.LookAt(coinTransform);
        }

        private Transform FindNearestCoinTransform()
        {
            if (_coinManager.Coins.Count <= 0) return null;

            var nearestCoinDistance = float.MaxValue;
            Transform nearestCoin = null;

            foreach (var coin in _coinManager.Coins)
            {
                var distance = Vector3.Distance(transform.position, coin.transform.position);
                if (distance < nearestCoinDistance)
                {
                    nearestCoinDistance = distance;
                    nearestCoin = coin.transform;
                }
            }

            return nearestCoin;
        }
    }
}