using UnityEngine;

namespace Week_10_Platformer
{
    public class PrefabCreator : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _spawnPoint;
        
        public void Create()
        {
            Instantiate(_prefab, _spawnPoint.position, _spawnPoint.rotation);
        }
    }
}
