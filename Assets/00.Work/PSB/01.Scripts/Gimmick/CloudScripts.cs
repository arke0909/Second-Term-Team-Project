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



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cloud")
        {
            rb.velocity = new Vector2(rb.velocity.x, power);
        }
    }

}
