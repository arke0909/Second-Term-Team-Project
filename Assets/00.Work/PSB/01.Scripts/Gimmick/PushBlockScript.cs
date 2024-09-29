using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PushBlockScript : MonoBehaviour
{
    public float pullForce = 5f;
    public float detectionRange = 5f;
    private Transform player; 
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindWithTag("PlayerCollider").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Debug.Log("1");
            float distance = Vector2.Distance(transform.position, player.position);
            Debug.Log("2");
            if (distance < detectionRange)
            {
                Debug.Log("3");
                Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
                rb.AddForce(direction * pullForce);
            }
        }
        else if (player == null)
        {
            Debug.Log("10");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
