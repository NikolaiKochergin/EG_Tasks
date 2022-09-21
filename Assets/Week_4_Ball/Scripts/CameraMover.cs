using System.Collections.Generic;
using UnityEngine;

namespace Week_4_HomeTask_Ball
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private readonly List<Vector3> _velocitiesList = new();

        private void Start()
        {
            for (var i = 0; i < 10; i++)
                _velocitiesList.Add(Vector3.zero);
        }

        private void Update()
        {
            var summ = Vector3.zero;

            foreach (var velocity in _velocitiesList)
                summ += velocity;

            transform.position = _player.transform.position;
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summ), Time.deltaTime * 10);
        }

        private void FixedUpdate()
        {
            _velocitiesList.Add(_player.Rigidbody.velocity);
            _velocitiesList.RemoveAt(0);
        }
    }
}