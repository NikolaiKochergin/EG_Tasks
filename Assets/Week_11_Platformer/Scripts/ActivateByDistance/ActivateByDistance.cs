using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Week_11_Platformer
{
    public class ActivateByDistance : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float DistanceToActivate = 20f;
        private Activator _activator;

        private bool _isActive = true;

        private void Start()
        {
            _activator = FindObjectOfType<Activator>();
            _activator.Add(this);
        }

        private void OnDestroy()
        {
            _activator.Remove(this);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.gray;
            Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
        }
#endif

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
    }
}