using UnityEngine;

namespace Week_3_HomeTask_ChessBoard
{
    public class BoardSpawner : MonoBehaviour
    {
        [SerializeField] private Cube _cubePrefab;
        [SerializeField] private Material _materialBlack;
        [SerializeField] private Material _materialWhite;
        [SerializeField] private int _boardSize;

        private void Start()
        {
            SpawnBoard();
        }

        private void SpawnBoard()
        {
            for (var i = 0; i < _boardSize; i++)
            for (var j = 0; j < _boardSize; j++)
            {
                var position = new Vector3(i, j, 0) * _cubePrefab.transform.localScale.x;
                var spawnedCube = Instantiate(_cubePrefab, position, Quaternion.identity, transform);

                spawnedCube.Renderer.material = (i + j) % 2 == 0 ? _materialBlack : _materialWhite;
            }
        }
    }
}