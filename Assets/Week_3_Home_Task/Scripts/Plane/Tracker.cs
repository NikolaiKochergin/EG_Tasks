using UnityEngine;

namespace Week_3_HomeTask_Plane
{
    public class Tracker : MonoBehaviour
    {
        [SerializeField] private GameObject _trackedObject;

        private void Update()
        {
            if(_trackedObject == null)
                return;
            
            transform.position = new Vector3(_trackedObject.transform.position.x, _trackedObject.transform.position.y,
                transform.position.z);
        }
    }
}