using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyComponent
{
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        Invoke("NextAction", 3);
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        Vector2 frontVect = new Vector2(rigid.position.x + nextMove * 0.2f, rigid.position.y);
        Debug.DrawRay(frontVect, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVect, Vector3.down, 1, LayerMask.GetMask("Ground"));
        try
        {
            if (rayHit.collider == null)
            {
                FlipEnemy();
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
        
    }

    private void FlipEnemy()
    {
        nextMove *= -1;
        sprite.flipX = nextMove == -4;
        CancelInvoke();
        Invoke("NextAction", 3);
    }

    public void NextAction()
    {
        nextMove = speed;

        anim.SetInteger("WalkSpeed", nextMove *= -1);

        if (nextMove != 0)
        {
            sprite.flipX = nextMove == -4;
        }

        float nextThinkTime = UnityEngine.Random.Range(2f, 5f);
        Invoke("NextAction", nextThinkTime);
    }

}
