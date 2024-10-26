using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monosingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private T _instance = null;
    public T Instance => _instance;

    protected virtual void Awake()
    {
        if (_instance == null)
            _instance = FindObjectOfType<T>();

        DontDestroyOnLoad(this);
    }
}
