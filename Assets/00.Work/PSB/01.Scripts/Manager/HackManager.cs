using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HackManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerTrans;
    [SerializeField] private Grid grid;
    [SerializeField] private GameObject obj;

    private void Start()
    {
        obj.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.transform.position = new Vector2(playerTrans.position.x, playerTrans.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Vector3 rot = grid.transform.rotation.eulerAngles;
            rot.x = 180;
            grid.transform.rotation = Quaternion.Euler(rot);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ShowObj();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            player.transform.position = new Vector2(player.transform.position.x + 5, player.transform.position.y);
        }
    }

    private IEnumerator ShowObj()
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(5f);
        obj.SetActive(false);
    }

}
