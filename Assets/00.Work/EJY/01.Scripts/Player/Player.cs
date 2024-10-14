using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

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

    private StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = GetComponent<StateMachine>();
        _components = new Dictionary<Type, IPlayerComponent>();

        SetPlayerCompo();

        _input.Movement += Flip;
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
