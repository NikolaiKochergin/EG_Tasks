using System;
using UnityEngine;

namespace Week_9_Platformer
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float _timeScale = 0.2f;
        
        private float _startFixedDeltaTime;

        private void Start()
        {
            _startFixedDeltaTime = Time.fixedDeltaTime;
        }

        private void Update()
        {
            if (Input.GetMouseButton(1))
                Time.timeScale = _timeScale;
            else
                Time.timeScale = 1.0f;

            Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
        }

        private void OnDestroy()
        {
            Time.fixedDeltaTime = _startFixedDeltaTime;
        }
    }
}