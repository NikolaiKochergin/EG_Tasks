using UnityEngine;

namespace Week_11_Platformer
{
    public class RopeGun : MonoBehaviour
    {
        [SerializeField] private Hook _hook;
        [SerializeField] private Transform _spawn;
        [SerializeField] private float _speed;

        private void Update()
        {
            if(Input.GetMouseButtonDown(2))
                Shot();
        }

        private void Shot()
        {
            _hook.StopFix();
            _hook.transform.position = _spawn.position;
            _hook.transform.rotation = _spawn.rotation;
            _hook.Rigidbody.velocity = _spawn.forward * _speed;
        }
    }
}
