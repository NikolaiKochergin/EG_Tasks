using UnityEditor;
using UnityEngine;

namespace Week_9_Platformer
{
    public class ActivateByDistance : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float DistanceToActivate = 20f;

        private bool _isActive = true;
        private Activator _activator;
        
        private void Start()
        {
            _activator = FindObjectOfType<Activator>();
            _activator.Add(this);
        }

        public void CheckDistance(Vector3 playerPosition)
        {
            var distance = Vector3.Distance(transform.position, playerPosition);

            if (_isActive)
            {
                if (distance > DistanceToActivate + 2f)
                    Deactivate();
            }
            else
            {
                if (distance < DistanceToActivate) 
                    Activate();
            }
        }

        public void Activate()
        {
            _isActive = true;
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            _isActive = false;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _activator.Remove(this);
        }

        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.gray;
            Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
        }
    }
}