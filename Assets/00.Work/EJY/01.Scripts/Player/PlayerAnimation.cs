using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private Animator AnimaCompo;
    private PlayerMovement _playerMovement;

    public void Initialize(Player player)
    {
        _player = player;
        AnimaCompo = GetComponent<Animator>();
        _playerMovement = _player.GetCompo<PlayerMovement>();
    }
}
