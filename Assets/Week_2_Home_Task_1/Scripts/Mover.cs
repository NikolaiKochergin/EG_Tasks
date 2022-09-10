using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _rotationSpeed;

    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = _defaultSpeed;
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.LeftShift))
            _currentSpeed = _defaultSpeed * 3;

        if (UnityEngine.Input.GetKeyUp(KeyCode.LeftShift))
            _currentSpeed = _defaultSpeed;
        
        var h = UnityEngine.Input.GetAxis("Horizontal");
        var v = UnityEngine.Input.GetAxis("Vertical");

        var offset = new Vector3(h, 0, v) * _currentSpeed * Time.deltaTime;
        transform.Translate(offset);

        var yRotation = UnityEngine.Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, yRotation * _rotationSpeed * Time.deltaTime, 0));
    }
}