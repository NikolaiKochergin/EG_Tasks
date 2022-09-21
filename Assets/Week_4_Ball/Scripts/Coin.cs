using UnityEngine;

namespace Week_4_HomeTask_Ball
{
    public class Coin : MonoBehaviour
    {
        private CoinManager _coinManager;
        
        public void Initialize(CoinManager coinManager)
        {
            _coinManager = coinManager;
        }

        public void Destroy()
        {
            _coinManager.RemoveCoin(this);
            Destroy(gameObject);
        }
    }
}