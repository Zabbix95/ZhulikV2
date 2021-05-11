using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    private Animator _animator;
    private CharacterController _controller;  
    private float _currentSpeed;
    private float _speedWalk = 2.0f;
    private float _speedRun = 4.0f;    
    private float _playerRotationSpeed = 150f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float _currentSpeed = Input.GetKey(KeyCode.LeftShift) ? _speedRun : _speedWalk;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");        

        if (z != 0)
        {   
            _controller.Move(transform.forward * z * _currentSpeed * Time.deltaTime);
            _animator.SetFloat("Speed", z * _currentSpeed);
        }   
        if (x != 0)
        {
            transform.Rotate(transform.up * x * _playerRotationSpeed * Time.deltaTime);
        }
    }
}