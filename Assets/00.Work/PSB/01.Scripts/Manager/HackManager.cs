using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HackManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerTrans;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.transform.position = new Vector2(player.transform.position.x + 5, player.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.transform.position = new Vector2(playerTrans.position.x, playerTrans.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            
        }
    }

}
