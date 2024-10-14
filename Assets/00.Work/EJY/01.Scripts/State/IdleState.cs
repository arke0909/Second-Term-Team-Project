using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Player player, string animaName, StateMachine stateMachine) : base(player, animaName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (_groundChecker.IsGround.Value)
            _playerMovement.RbCompo.velocity = Vector2.zero;
    }

    public override void StateUpdate()
    {
        if(Mathf.Abs(_inputReader.MoveDir.x) > 0)
            _stateMachine.ChageState(PlayerStateEnum.Walk);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
