using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    
    private Rigidbody2D RbCompo;
    private GroundChecker GroundCheckerCompo;

    private Player _player;
    private InputReaderSO _input;

    public void Initialize(Player player)
    {
        _player = player;

        RbCompo = GetComponent<Rigidbody2D>();
        _input = _player.GetCompo<InputReaderSO>();
        GroundCheckerCompo = GetComponentInChildren<GroundChecker>();

        _input.Jump += Jump;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 moveDir = _input.moveDir;
        RbCompo.velocity = new Vector2(moveDir.x * _moveSpeed, RbCompo.velocity.y);
    }

    private void Jump()    
    {
        if(GroundCheckerCompo.GroundCheck())
        RbCompo.AddForce(Vector2.up * _jumpPower,ForceMode2D.Impulse);
    }
}