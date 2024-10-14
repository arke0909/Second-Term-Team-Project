using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResetBlock : MonoBehaviour
{
    [SerializeField] private GameObject zzPanel;
    private void Start()
    {
        zzPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SaveLoadManager.Instance.LoadPlayerData();
            StartCoroutine(StartBanter());
        }
        if (collision.gameObject.tag == "PushBlock")
        {
            collision.gameObject.SetActive(false);
        }

    }

    private IEnumerator StartBanter()
    {
        zzPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        zzPanel.SetActive(false);
    }

}
