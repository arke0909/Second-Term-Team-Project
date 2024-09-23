using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _input;
    private Dictionary<Type, IPlayerComponent> _components;

    private void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponent>();

        GetComponentsInChildren<IPlayerComponent>().ToList().ForEach(x => _components.Add(x.GetType(), x));
        _components.Add(_input.GetType(), _input);
        _components.Values.ToList().ForEach(compo => compo.Initialize(this));

        _input.Movement += Flip;
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
