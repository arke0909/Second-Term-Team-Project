using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : WalkState
{
    public FallState(Player player, string animaName, StateMachine stateMachine) : base(player, animaName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _groundChecker.IsGround.OnValueChanged += HandleIsGroundChange;
    }

    private void HandleIsGroundChange(bool prev, bool next)
    {
        if (next)
            _stateMachine.ChageState(PlayerStateEnum.Idle);
    }

    public override void Exit()
    {
        _groundChecker.IsGround.OnValueChanged -= HandleIsGroundChange;
        base.Exit();
    }
}
