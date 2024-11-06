using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class EnemyJumpFollow : EnemyComponent
{
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponentInParent<Rigidbody2D>();
        playerRB = player.GetComponent<Rigidbody2D>();
        enemyMove = GetComponentInParent<EnemyMove>();
        anim = GetComponentInParent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 frontVect = new Vector2(rigid.position.x, rigid.position.y + nextMove * 4f);
        Debug.DrawRay(frontVect, Vector3.up, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVect, Vector3.up, 4, LayerMask.GetMask("Player"));
        if (rayHit.collider != null)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (isJumped == false)
        {
            rigid.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            enemyMove.nextMove = 0;
            anim.SetInteger("WalkSpeed", 0);
            isJumped = true;
        }
        if (isJumped == true)
        {
            enemyMove.nextMove *= 1;
        }
    }


}
