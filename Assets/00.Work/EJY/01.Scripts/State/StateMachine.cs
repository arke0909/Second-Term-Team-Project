using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour, IPlayerComponent
{
    private Player _player;

    private PlayerStateEnum _currentState;
    private Dictionary<PlayerStateEnum, State> _playerState;

    private void Awake()
    {
        _playerState = new Dictionary<PlayerStateEnum, State>();
    }

    private void Start()
    {
        CreateState();

        ChageState(PlayerStateEnum.Idle);
    }

    private void Update()
    {
        _playerState[_currentState].StateUpdate();
    }

    private void FixedUpdate()
    {
        _playerState[_currentState].StateFixedUpdate();
    }

    public void ChageState(PlayerStateEnum state)
    {
        _playerState[_currentState].Exit();
        _currentState = state;
        _playerState[_currentState].Enter();
    }

    private void CreateState()
    {
        foreach (PlayerStateEnum state in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string enumName = state.ToString();
            Type t = Type.GetType(enumName + "State");

            State playerState = Activator.CreateInstance(t, _player, "Player" + enumName, this) as State;

            _playerState.Add(state, playerState);
        }
    }

    public void Initialize(Player player)
    {
        _player = player;
    }
}
