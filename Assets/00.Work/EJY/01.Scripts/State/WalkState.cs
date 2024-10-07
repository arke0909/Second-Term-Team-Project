using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
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
        if (_inputReader.MoveDir.x == 0 && _groundChecker.IsGround.Value)
            _player.ChageState(PlayerStateEnum.Idle);
        _playerMovement.Movement(_inputReader.MoveDir);
    }

    public override void StateFixedUpdate()
    {
    }

    public override void Exit()
    {
        base.Exit();
    }
}
