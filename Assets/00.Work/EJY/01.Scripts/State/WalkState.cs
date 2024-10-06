using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : GroundState
{
    public WalkState(Player player, string animaName) : base(player, animaName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void StateUpdate()
    {
        if (_inputReader.moveDir.x == 0)
            _player.ChageState(PlayerStateEnum.Idle);
    }

    public override void StateFixedUpdate()
    {
        _playerMovement.Movement();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
