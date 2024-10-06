using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public JumpState(Player player, string animaName) : base(player, animaName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _playerMovement.Jump();
        Debug.Log($"มกวม {this}");
    }

    public override void Exit()
    {
        base.Exit();
    }
}
