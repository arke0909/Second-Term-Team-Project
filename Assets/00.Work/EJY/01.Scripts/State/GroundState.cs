using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundState : State
{
    public GroundState(Player player, string animaName) : base(player, animaName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _groundChecker.IsGround.OnValueChanged += HandleIsGroundChange;
        HandleIsGroundChange(false, _groundChecker.IsGround.Value);
        
    }

    private void HandleIsGroundChange(bool prev, bool next)
    {
        if (next == false)
            _player.ChageState(PlayerStateEnum.Fall);
    }

    public override void Exit()
    {
        _groundChecker.IsGround.OnValueChanged -= HandleIsGroundChange;
        base.Exit();
    }
}
