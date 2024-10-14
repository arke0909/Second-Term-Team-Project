using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : WalkState
{
    public JumpState(Player player, string animaName, StateMachine stateMachine) : base(player, animaName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _playerMovement.Jump();
    }

    

    public override void Exit()
    {
        base.Exit();
    }
}
