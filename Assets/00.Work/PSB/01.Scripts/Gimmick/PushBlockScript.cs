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

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance < detectionRange)
            {
                Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
                rb.AddForce(direction * pullForce);
            }
        }
        else if (player == null)
        {
            Debug.LogWarning("No Player");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
