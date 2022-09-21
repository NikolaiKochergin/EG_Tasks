using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Week_4_HomeTask_Ball
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private int _coinCount;
        [SerializeField] private float _spawnWidth;

        private List<Coin> _coins;

        public IReadOnlyList<Coin> Coins => _coins;

        private void Start()
        {
            _coins = new List<Coin>();
            SpawnCoins();
            SetCoinsText();
        }

        private void SpawnCoins()
        {
            for (var i = 0; i < _coinCount; i++)
            {
                var coin = Instantiate(_coinPrefab, GenerateCoinPosition(), Quaternion.identity, transform);
                coin.Initialize(this);
                _coins.Add(coin);
            }
        }

        private Vector3 GenerateCoinPosition()
        {
            return new Vector3(Random.Range(-_spawnWidth, _spawnWidth), 0.25f, Random.Range(-_spawnWidth, _spawnWidth));
        }

        private void SetCoinsText()
        {
            _text.text = "Осталось собрать : " + _coins.Count;
        }

        private void CheckWin()
        {
            if (_coins.Count <= 0)
                _text.text = "Все монетки собраны.";
        }
        
        public void RemoveCoin(Coin coin)
        {
            _coins.Remove(coin);
            SetCoinsText();
            CheckWin();
        }
    }
}