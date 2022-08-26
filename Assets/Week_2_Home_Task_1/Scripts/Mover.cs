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
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _currentSpeed = _defaultSpeed * 3;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            _currentSpeed = _defaultSpeed;
        
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var offset = new Vector3(h, 0, v) * _currentSpeed * Time.deltaTime;
        transform.Translate(offset);

        var yRotation = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, yRotation * _rotationSpeed * Time.deltaTime, 0));
    }
}