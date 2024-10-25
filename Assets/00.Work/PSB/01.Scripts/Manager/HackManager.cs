using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.transform.position = new Vector2(player.transform.position.x + 5, player.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 2);
        }
    }

}
