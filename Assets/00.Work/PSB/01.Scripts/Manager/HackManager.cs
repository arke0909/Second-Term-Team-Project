using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerTrans;
    [SerializeField] private GameObject rock;
    [SerializeField] private Rigidbody2D rockRb;

    private void Start()
    {
        rockRb = rock.GetComponent<Rigidbody2D>();
    }

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
            rockRb.gravityScale = 7f;
        }
    }

}
