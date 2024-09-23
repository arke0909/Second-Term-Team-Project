using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlock : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))  //Save
        {
            GameData character = new GameData(gameObject.name, gameObject.transform.position);
            
            DataController.Save(character, "save_001");
        }
        if (Input.GetKeyDown(KeyCode.L))  //Load
        {
            GameData loadData = DataController.Load("save_001");
            Debug.Log(string.Format("LoadData Result => name : {0}, pos : {1}", loadData.name, loadData.pos));
            gameObject.transform.position = loadData.pos;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(5f, rb.velocity.y);
    }
}
