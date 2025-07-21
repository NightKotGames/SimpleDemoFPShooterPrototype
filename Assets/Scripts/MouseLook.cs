using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField, Range(1,5)] private float _mouseSentitivity;
    [Space(5),SerializeField] private Transform _playerBody;

    private InputControl _inputSystem;

    private float _xRotation;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _inputSystem = new InputControl();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }
    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    private void Update()
    {

        Vector2 _mousePos = _inputSystem.Player.MouseLook.ReadValue<Vector2>();
        LookRotation(_mousePos);

    }

    private void LookRotation(Vector2 rotation)
    {
        float _mouseX = rotation.x * _mouseSentitivity * Time.deltaTime;
        float _mouseY = rotation.y * _mouseSentitivity * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -75f, 75f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * _mouseX);
    }

}
