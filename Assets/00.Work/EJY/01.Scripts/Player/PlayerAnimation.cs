using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    public Animator AnimaCompo { get; private set; }

    public void Initialize(Player player)
    {
        _player = player;
        AnimaCompo = GetComponent<Animator>();
    }
}
