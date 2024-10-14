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
            player.transform.position = new Vector2(4.57f, 21.21f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.transform.position = new Vector2(45.78f, 30.48f);
        }
    }

}
