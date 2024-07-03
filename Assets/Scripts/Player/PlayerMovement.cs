using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movementInput;
    private Animator _animator;

    [SerializeField] private float _speed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        SetMovementVelocity();
        FlipPlayer();
        UpdateAnimator();
    }

    private void SetMovementVelocity()
    {
        _rigidbody2D.velocity = _movementInput * _speed;
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void FlipPlayer()
    {
        if (_movementInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_movementInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void UpdateAnimator()
    {
        bool isWalking = _movementInput != Vector2.zero;
        _animator.SetBool("isWalking", isWalking);
    }
}