using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBlockEffector : Gimmick
{
    [SerializeField] private PlatformEffector2D effector;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool isVisible = false;

    public float distance = 10f;

    private void Start()
    {
        effector.enabled = true;
        spriteRenderer.enabled = false;
    }

    private void Awake()
    {
        isVisible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isVisible)
        {
            effector.enabled = false;
            spriteRenderer.enabled = true;
        }
    }

    public override bool Check()
    {
        return true;
    }

    public override void EffectGimmick()
    {
    }

    /*private void CheckArc()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);

        if (hit.collider != null)
        {
            int layerMask = effector.colliderMask;

            int playerLayer = LayerMask.NameToLayer("Player");

            if (hit.collider.gameObject.layer == playerLayer)
            {
                float surfaceArc = effector.surfaceArc;
                float angle = Vector2.Angle(Vector2.up, hit.normal);

                if (angle <= surfaceArc / 2)
                {
                    spriteRenderer.enabled = true;
                    effector.enabled = false;
                }
            }
        }



    }*/



}
