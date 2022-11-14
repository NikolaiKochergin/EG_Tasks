using System.Collections.Generic;
using UnityEngine;

namespace Week_10_Platformer
{
    public class Activator : MonoBehaviour
    {
        [SerializeField] private List<ActivateByDistance> _objectsToActivate;
        [SerializeField] private Transform _playerTransform;

        private void Update()
        {
            foreach (var objectToActivate in _objectsToActivate)
                objectToActivate.CheckDistance(_playerTransform.position);
        }

        public void Add(ActivateByDistance activateByDistance)
        {
            _objectsToActivate.Add(activateByDistance);
        }

        public void Remove(ActivateByDistance activateByDistance)
        {
            _objectsToActivate.Remove(activateByDistance);
            if(_objectsToActivate.Count == 0)
                Debug.Log("You win");
        }
    }
}