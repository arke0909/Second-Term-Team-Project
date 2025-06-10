using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public DeadState(Player player, string animaName, StateMachine stateMachine) : base(player, animaName, stateMachine)
    {

    }

    public override void Enter()
    {
        _player.gameObject.SetActive(false);
    }

    public override void Exit()
    {
    }
}
