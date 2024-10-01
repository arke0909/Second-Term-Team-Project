using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResetBlock : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SaveLoadManager.Instance.LoadPlayerData();
        }
    }
}
