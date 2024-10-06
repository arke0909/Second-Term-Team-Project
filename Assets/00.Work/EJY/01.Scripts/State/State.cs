using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class State
{
    protected Player _player;
    protected int _animaHash;

    #region PlayerComponentRegion
    protected PlayerAnimation _animator;
    protected PlayerMovement _playerMovement;
    protected InputReaderSO _inputReader;
    protected GroundChecker _groundChecker;
    #endregion

    public State(Player player, string animaName)
    {
        _player = player;
        _animaHash = Animator.StringToHash(animaName);

        _animator = _player.GetCompo<PlayerAnimation>();
        _playerMovement = _player.GetCompo<PlayerMovement>();
        _inputReader = _player.GetCompo<InputReaderSO>();
        _groundChecker = _player.GetCompo<GroundChecker>();

        _inputReader.Jump += HandleChangeJumpState;
    }

    private void HandleChangeJumpState()
    {
        if (_groundChecker.IsGround.Value)
            _player.ChageState(PlayerStateEnum.Jump);
    }

    public virtual void Enter()
    {
        _animator.AnimaCompo.Play(_animaHash);
    }

    public virtual void StateUpdate()
    {
    }

    public virtual void StateFixedUpdate()
    {
        if (_playerMovement.RbCompo.velocity.y < 0)
            _player.ChageState(PlayerStateEnum.Fall);
    }

    public virtual void Exit()
    {
    }
}
