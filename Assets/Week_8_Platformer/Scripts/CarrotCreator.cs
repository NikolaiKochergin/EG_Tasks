using UnityEngine;

namespace Week_8_Platformer
{
    public class CarrotCreator : MonoBehaviour
    {
        [SerializeField] private Carrot _carrotPrefab;
        [SerializeField] private Transform _spawnPoint;
        
        public void Create()
        {
            Instantiate(_carrotPrefab, _spawnPoint.position, Quaternion.identity);
        }
    }
}
