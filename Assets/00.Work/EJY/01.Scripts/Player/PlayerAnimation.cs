using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IPlayerComponent
{
    private Animator AnimaCompo;
    private SpriteRenderer SpriteRendererCompo;
    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;

        AnimaCompo = GetComponent<Animator>();
        SpriteRendererCompo = GetComponent<SpriteRenderer>();
    }
}
