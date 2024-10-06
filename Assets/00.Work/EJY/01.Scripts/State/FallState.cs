using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : State
{
    public FallState(Player player, string animaName) : base(player, animaName)
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
            _player.ChageState(PlayerStateEnum.Idle);
    }

    public override void Exit()
    {
        _groundChecker.IsGround.OnValueChanged -= HandleIsGroundChange;
        base.Exit();
    }
}
