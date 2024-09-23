using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public GameData(string _name, Vector3 _pos)
    {
        go.name = name;
        go.transform.position = pos;

        name = _name;
        pos = _pos;
    }
    GameObject go = GameObject.Find("Test");
    public string name;
    public Vector3 pos;
}
