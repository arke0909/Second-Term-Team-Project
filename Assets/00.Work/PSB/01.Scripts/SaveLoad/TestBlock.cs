using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlock : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameData character = new GameData("D", new Vector3(0 ,0 ,1));
            DataController.Save(character, "save_001");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameData loadData = DataController.Load("save_001");
            Debug.Log(string.Format("LoadData Result => name : {0}, pos : {1}", loadData.name, loadData.pos));
        }
    }
}
