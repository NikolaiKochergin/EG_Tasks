using UnityEngine;

namespace Week_6_Platformer_Beginning
{
    public class Pointer : MonoBehaviour
    {
        [SerializeField] private Transform _aim;

        private Camera _camera;
        private Plane _plane;

        private void Start()
        {
            if (Camera.main != null) _camera = Camera.main;
            _plane = new Plane(Vector3.back, Vector3.zero);
        }

        private void Update()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);

            _plane.Raycast(ray, out float distance);
            Vector3 point = ray.GetPoint(distance);
            _aim.transform.position = point;

            Vector3 toAim = _aim.position - transform.position;
            transform.rotation = Quaternion.LookRotation(toAim);
        }
    }
}