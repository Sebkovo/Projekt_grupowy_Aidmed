using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class player_controller : MonoBehaviour
{
    Vector2 moveInput;

    public float WalkSpeed = 2f;
    Rigidbody2D rb;
    Animator animator;

    private bool _isMoving = false;
    private int _direction = 0;

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool("moving",value);
        }
    }

    public int Direction
    {
        get
        {
            return _direction;
        }
        private set
        {
            _direction = value;
            animator.SetInteger("direction", value);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * WalkSpeed, moveInput.y * WalkSpeed);
        if (Math.Abs(moveInput.y) < Math.Abs(moveInput.x))
        {
            if (moveInput.x < 0)
                Direction = 1;
            else
                Direction = 3;
        }
        else
        {
            if (moveInput.y < 0)
                Direction = 0;
            else
                Direction = 2;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        if (!IsMoving)
            if (Math.Abs(moveInput.y) < Math.Abs(moveInput.x))
            {
                if (moveInput.x < 0)
                    Direction = 1;
                else
                    Direction = 3;
            }
            else
            {
                if (moveInput.y < 0)
                    Direction = 0;
                else
                    Direction = 2;
            }
    }
}
