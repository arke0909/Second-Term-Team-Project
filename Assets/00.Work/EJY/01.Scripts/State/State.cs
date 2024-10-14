using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class State
{
    protected Player _player;
    protected StateMachine _stateMachine;
    protected int _animaHash;

    #region PlayerComponentRegion
    protected PlayerAnimation _animator;
    protected PlayerMovement _playerMovement;
    protected InputReaderSO _inputReader;
    protected GroundChecker _groundChecker;
    #endregion

    public State(Player player, string animaName, StateMachine stateMachine)
    {
        _player = player;
        _stateMachine = stateMachine;
        _animaHash = Animator.StringToHash(animaName);

        _animator = _player.GetCompo<PlayerAnimation>();
        _playerMovement = _player.GetCompo<PlayerMovement>();
        _inputReader = _player.GetCompo<InputReaderSO>();
        _groundChecker = _player.GetCompo<GroundChecker>();
    }

    private void HandleChangeJumpState()
    {
        if (_groundChecker.IsGround.Value)
            _stateMachine.ChageState(PlayerStateEnum.Jump);
    }

    public virtual void Enter()
    {
        _animator.AnimaCompo.Play(_animaHash);
        _inputReader.Jump += HandleChangeJumpState;
    }

    public virtual void StateUpdate()
    {
    }

    public virtual void StateFixedUpdate()
    {
    }

    public virtual void Exit()
    {
        _inputReader.Jump -= HandleChangeJumpState;
    }
}
