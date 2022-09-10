using UnityEngine;

namespace Week_3_HomeTask_ChessBoard
{
    public class Cube : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        public Renderer Renderer => _renderer;
    }
}