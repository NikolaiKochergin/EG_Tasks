using UnityEngine;

namespace Week_5_Canvas
{
    public class MaterialSetter : MonoBehaviour
    {
        [SerializeField] private Renderer[] _renderers;

        public void SetMaterial(Material material)
        {
            foreach (var renderer in _renderers) renderer.material = material;
        }
    }
}