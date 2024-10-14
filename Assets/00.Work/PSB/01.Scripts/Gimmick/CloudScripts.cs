using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScripts : MonoBehaviour
{
    public float power = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cloud")
        {
            rb.velocity = new Vector2(rb.velocity.x, power);
            Debug.Log("yy");
        }
    }

}
