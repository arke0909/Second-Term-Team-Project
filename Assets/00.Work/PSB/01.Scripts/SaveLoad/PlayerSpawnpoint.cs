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
        if (collision.tag == "SpawnPoint")
        {
            if (collision.tag == "DeathBlock")
            {
                Vector2 v2 = new Vector2(-1.8f, 2.35f);
                transform.parent.position = v2;
            }
            else
            {
                transform.parent.position = collision.transform.position;
                SaveLoadManager.Instance.SavePlayerData();
            }

        }
    }

}
