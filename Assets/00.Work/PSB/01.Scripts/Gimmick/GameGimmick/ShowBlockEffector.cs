using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBlockEffector : MonoBehaviour
{
    private PlatformEffector2D effector;
    private SpriteRenderer spriteRenderer;

    private bool used = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        effector = GetComponent<PlatformEffector2D>();

        spriteRenderer.enabled = false;
        effector.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!used)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                float angle = Vector2.Angle(contact.normal, Vector2.up);

                if (angle <= effector.surfaceArc / 2f)
                {
                    effector.enabled = false;
                    spriteRenderer.enabled = true;
                    used = true;
                    CollisionObjectAddForce(collision);
                    break;
                }
            }
        }
    }

    private void CollisionObjectAddForce(Collision2D collision)
    {
        throw new NotImplementedException();
    }
}
