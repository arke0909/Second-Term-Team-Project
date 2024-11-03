using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestDieScript : Gimmick, IInitializable
{
    [SerializeField] private GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)  //Player Layer
        {
            player.SetActive(false);
        }
    }

    public override bool Check()
    {
        return true;
    }

    public void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
