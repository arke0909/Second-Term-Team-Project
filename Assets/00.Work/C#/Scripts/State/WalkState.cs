using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public WalkState(Player player, string animaName, StateMachine stateMachine) : base(player, animaName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void StateUpdate()
    {
        if (_inputReader.MoveDir.x == 0 && _groundChecker.IsGround.Value)
            _stateMachine.ChageState(PlayerStateEnum.Idle);
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
