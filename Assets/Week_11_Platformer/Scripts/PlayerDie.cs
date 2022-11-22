using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Week_11_Platformer
{
    public class PlayerDie : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ConstantForce _constantForce;

        private List<MonoBehaviour> _monoBehaviours = new();

        private void Awake()
        {
            _monoBehaviours.AddRange(GetComponents<MonoBehaviour>().ToList());
            _monoBehaviours.AddRange(GetComponentsInChildren<MonoBehaviour>().ToList());
        }

        public void MakeDied()
        {
            _rigidbody.isKinematic = true;
            _constantForce.enabled = false;
            
            foreach (var mono in _monoBehaviours) mono.enabled = false;
            
            Debug.Log("You Lose");
        }
    }
}