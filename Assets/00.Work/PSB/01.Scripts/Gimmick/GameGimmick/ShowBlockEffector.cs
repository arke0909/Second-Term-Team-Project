using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBlockEffector : MonoBehaviour
{
    [SerializeField] private float _replactionPower;

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
        foreach (ContactPoint2D contact in collision.contacts)
        {
            float angle = Vector2.Angle(contact.normal, Vector2.up);

            if (angle <= effector.surfaceArc / 2f)
            {
                if (!used)
                {
                    effector.enabled = false;
                    spriteRenderer.enabled = true;
                    used = true;
                }

                StartCoroutine(CollisionObjectAddForce(collision));

                break;
            }
        }
    }

    private IEnumerator CollisionObjectAddForce(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerMovement playerMovement))
        {
            Vector2 addDir = new Vector2(playerMovement.RbCompo.velocity.x, -_replactionPower);

            playerMovement.canMove = false;
            playerMovement.Stop();
            playerMovement.RbCompo.AddForce(addDir, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.2f);
            playerMovement.canMove = true;
            playerMovement.Stop();
        }
    }
}
