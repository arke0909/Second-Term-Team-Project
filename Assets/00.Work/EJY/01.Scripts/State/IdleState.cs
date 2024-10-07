using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Player player, string animaName) : base(player, animaName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void StateUpdate()
    {
        if(Mathf.Abs(_inputReader.MoveDir.x) > 0)
            _player.ChageState(PlayerStateEnum.Walk);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
