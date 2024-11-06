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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (Input.GetKeyDown(KeyCode.Alpha9))  //rigid.velocity.y > 0
            {
                Jump();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (Input.GetKeyDown(KeyCode.Alpha9))  //rigid.velocity.y > 0
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        rigid.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        enemyMove.nextMove = 0;
    }


}
