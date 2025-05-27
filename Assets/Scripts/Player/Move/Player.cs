using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;

    public Vector2 Movement { get; private set; } 

    private Controller _controller;
    private Rigidbody2D _rb;
    private Animator _animator;
    


    private void Awake()
    {
        _controller = new Controller();
        _animator = GetComponent<Animator>();      
        _rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        PlayerInput();
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        _controller.Enable();
    }

    public void PlayerInput()
    {
        Movement = _controller.Player.Move.ReadValue<Vector2>();
        _animator.SetFloat("MoveX", Movement.x);
        _animator.SetFloat("MoveY", Movement.y);
    }
     
    private void Move()
    {
        _rb.MovePosition(_rb.position + Movement * (_moveSpeed * Time.fixedDeltaTime));
    }


}
