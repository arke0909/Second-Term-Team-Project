using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;

    private Player _player;
    private InputReaderSO _input;
    public Rigidbody2D RbCompo { get; private set; }

    public float timeInAir;
    public float extraGravity = 20f, gravityDelay = 0.15f;

    public void Initialize(Player player)
    {
        _player = player;

        RbCompo = GetComponent<Rigidbody2D>();
        _input = _player.GetCompo<InputReaderSO>();
    }
    public void Movement()
    {
        Vector2 moveDir = _input.MoveDir;
        RbCompo.velocity = new Vector2(moveDir.x * _moveSpeed, RbCompo.velocity.y);
    }

    public void Jump()    
    {
        RbCompo.AddForce(Vector2.up * _jumpPower,ForceMode2D.Impulse);
    }
}