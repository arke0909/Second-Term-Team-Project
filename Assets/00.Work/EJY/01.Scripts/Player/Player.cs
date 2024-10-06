using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public enum PlayerStateEnum
{
    Idle,
    Walk,
    Jump,
    Fall
}
public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _input;
    private Dictionary<Type, IPlayerComponent> _components;

    [SerializeField]
    private PlayerStateEnum _currentState;
    private Dictionary<PlayerStateEnum, State> _playerState;

    private void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponent>();
        _playerState = new Dictionary<PlayerStateEnum, State>();

        SetPlayerCompo();

        CreateState();

        _input.Movement += Flip;

        ChageState(PlayerStateEnum.Idle);
    }

    private void CreateState()
    {
        foreach (PlayerStateEnum state in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string enumName = state.ToString();
            Type t = Type.GetType(enumName + "State");

            State playerState = Activator.CreateInstance(t, this,"Player" + enumName) as State;
            _playerState.Add(state, playerState);
        }
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

    private void SetPlayerCompo()
    {
        GetComponentsInChildren<IPlayerComponent>().ToList().ForEach(x => _components.Add(x.GetType(), x));
        _components.Add(_input.GetType(), _input);
        _components.Values.ToList().ForEach(compo => compo.Initialize(this));
    }

    public T GetCompo<T>() where T : class
    {
        Type t = typeof(T);

        if (_components.TryGetValue(t, out IPlayerComponent compo))
        {
            return compo as T;
        }
        return default;
    }

    public void Flip(Vector2 dir)
    {
        if (dir.x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (dir.x < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
}
