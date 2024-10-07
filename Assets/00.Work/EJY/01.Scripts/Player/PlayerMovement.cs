using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    
    public Rigidbody2D RbCompo { get; private set; }

    private Player _player;
    private InputReaderSO _input;

    public void Initialize(Player player)
    {
        _player = player;

        RbCompo = GetComponent<Rigidbody2D>();
        _input = _player.GetCompo<InputReaderSO>();
    }
    public void Movement(Vector2 moveDir)
    {
        RbCompo.velocity = new Vector2(moveDir.x * _moveSpeed, RbCompo.velocity.y);
        Debug.Log(moveDir);
    }

    public void Jump()    
    {
        RbCompo.AddForce(Vector2.up * _jumpPower,ForceMode2D.Impulse);
    }
}