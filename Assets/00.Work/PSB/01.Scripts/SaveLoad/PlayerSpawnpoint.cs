using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnpoint : MonoBehaviour
{
    [SerializeField] private Collider2D _collider2D;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1");
        if (collision.tag == "SpawnPoint")
        {
            transform.parent.position = collision.transform.position;
            Debug.Log("3");
            SaveLoadManager.Instance.SavePlayerData();
        }

    }

}
