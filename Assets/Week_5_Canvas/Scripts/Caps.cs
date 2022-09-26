using UnityEngine;

namespace Week_5_Canvas
{
    public class Caps : MonoBehaviour
    {
        [SerializeField] private GameObject[] _allCaps;

        public void SetCapBy(int index)
        {
            for (var i = 0; i < _allCaps.Length; i++)
                if (i == index)
                    _allCaps[i].SetActive(true);
                else
                    _allCaps[i].SetActive(false);
        }
    }
}