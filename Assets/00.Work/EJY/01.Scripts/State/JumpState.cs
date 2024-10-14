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

    public override void StateUpdate()
    {
        CalculatorInAirTime();
        ApplyExtraGravity();

        if (_playerMovement.RbCompo.velocity.y < 0)
            _stateMachine.ChageState(PlayerStateEnum.Fall);
    }

    public override void StateFixedUpdate()
    {
        _playerMovement.Movement();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void ApplyExtraGravity()
    {
        if (_playerMovement.timeInAir > _playerMovement.gravityDelay)
        {
            _playerMovement.RbCompo.AddForce(new Vector2(0, -_playerMovement.extraGravity));
        }
    }

    private void CalculatorInAirTime()
    {
        if (!_groundChecker.IsGround.Value)
            _playerMovement.timeInAir += Time.deltaTime;
        else
            _playerMovement.timeInAir = 0;
    }
}
