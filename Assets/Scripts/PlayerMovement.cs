using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{

    [SerializeField, Range(1, 10)] private float _moveSpeed;
    [Range(1, 10), SerializeField] private float _jumpHeight;

    [Space(5), SerializeField] private LayerMask _isGround;
    [SerializeField, Range(.01f, .1f)] private float _groundDistance;
    [SerializeField] private Transform _checkGround;

    [SerializeField] private bool _isGrounded;


    private InputControl _inputSystem;
    
    private CharacterController _characterController;
    private Vector3 _velocity;
    private float _gravity = -9.81f;


    private void Awake()
    {

        _inputSystem = new InputControl();
        _characterController = GetComponent<CharacterController>();

    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
        
    }


    #region Update

    private void Update()
    {

        Vector2 _direction = _inputSystem.Player.Move.ReadValue<Vector2>();
        Gravity();
        Jump();
        Move(_direction);

    }

    #endregion



    private void Move(Vector2 direction)
    {
        Vector3 movement = (direction.y * transform.forward) + (direction.x * transform.right);
        _characterController.Move(movement * _moveSpeed * Time.deltaTime);

    }

    private void Gravity()
    {
        _isGrounded = Physics.CheckSphere(_checkGround.position, _groundDistance, _isGround);
        if(_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void Shoot()
    {
        Debug.Log($"Shoot: ");
    }

    private void Jump()
    {
        if (_inputSystem.Player.Jump.triggered)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
    }

}
