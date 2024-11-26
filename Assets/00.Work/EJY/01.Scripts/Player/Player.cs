using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerStateEnum
{
    Idle,
    Walk,
    Jump,
    Fall,
    Dead
}
public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _input;
    private Dictionary<Type, IPlayerComponent> _components;

    public StateMachine StateMachine { get; private set; }

    public bool IsDead { get; private set; } = false;

    public UnityEvent JumpEvent;
    public UnityEvent LandingEvent;

    private void Awake()
    {
        StateMachine = GetComponent<StateMachine>();
        _components = new Dictionary<Type, IPlayerComponent>();

        SetPlayerCompo();
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

    public void SetDead() => StateMachine.ChageState(PlayerStateEnum.Dead);
}
