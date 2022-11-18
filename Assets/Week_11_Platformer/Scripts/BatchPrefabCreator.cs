using UnityEngine;

namespace Week_11_Platformer
{
    public class BatchPrefabCreator : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform[] _spawnPoints;

        [ContextMenu("Call Create")]
        public void Create()
        {
            foreach (var spawn in _spawnPoints) 
                Instantiate(_prefab, spawn.position, spawn.rotation);
        }
    }
}