using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

[Serializable]
public class GameData
{
    //instanc«“ øπ¡§

    public GameData(string _name, Vector3 _pos)
    {
        go.name = _name;
        pos = _pos;
    }
    GameObject go = GameObject.Find("Test");
    public string name;
    public Vector3 pos;
}
