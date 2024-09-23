using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlock : MonoBehaviour
{
    private void Start()
    {
        Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))  //Save
        {
            GameData character = new GameData(gameObject.name, gameObject.transform.position);
            
            DataController.Save(character, "save_001");
        }
        if (Input.GetKeyDown(KeyCode.V))  //Load
        {
            GameData loadData = DataController.Load("save_001");
            Debug.Log(string.Format("LoadData Result => name : {0}, pos : {1}", loadData.name, loadData.pos));
            gameObject.name = loadData.name;
            gameObject.transform.position = loadData.pos;
        }
    }

    public void Load()
    {
        GameData loadData = DataController.Load("save_001");
        Debug.Log(string.Format("LoadData Result => name : {0}, pos : {1}", loadData.name, loadData.pos));
        gameObject.name = loadData.name;
        gameObject.transform.position = loadData.pos;
    }

}
