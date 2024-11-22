using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    /*    private void Awake()
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
    */

    private Rigidbody2D rigid;
    private Animator anim;
    private SpriteRenderer sprite;

    public float speed = 2f; // �̵� �ӵ�
    public float jumpPower = 5f; // ���� ��
    private float nextMove; // ���� �̵� ����
    private bool isJumped = false; // ���� ����
    private float flipWaitTime; // ���� ��ȯ ��� �ð�
    private bool canFlip = true; // ���� ��ȯ ���� ����

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        StartMovement();
        SetRandomFlipWaitTime(); // �ʱ� ���� ��ȯ ��� �ð� ����
    }

    private void FixedUpdate()
    {
        Move();

        // �� ���� �� ���� ��ȯ
        if (IsOnWall() && canFlip)
        {
            FlipDirection();
        }

        // speed�� 0�� �� ���� �ִϸ��̼� ����
        if (nextMove == 0 && !isJumped)
        {
            Jump();
        }
    }

    private void StartMovement()
    {
        nextMove = speed;
        anim.SetInteger("WalkSpeed", (int)nextMove);
        Invoke("StartMovement", UnityEngine.Random.Range(2f, 5f)); // Random Move Timer
    }

    private void Move()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        anim.SetInteger("WalkSpeed", (int)nextMove); // �̵� �߿��� Idle �ִϸ��̼� ���
    }

    private bool IsOnWall()
    {
        // ���ʿ� ���� �ִ��� ����
        Vector2 frontVect = new Vector2(rigid.position.x + nextMove * 0.5f, rigid.position.y);
        RaycastHit2D hit = Physics2D.Raycast(frontVect, Vector2.right * Mathf.Sign(nextMove), 0.1f, LayerMask.GetMask("Ground"));
        return hit.collider != null; // ���� ������ true ��ȯ
    }

    private void FlipDirection()
    {
        if (canFlip)
        {
            nextMove *= -1; // �̵� ���� ����
            sprite.flipX = nextMove < 0; // ���⿡ ���� ��������Ʈ ����
            isJumped = false; // ���� ���� �ʱ�ȭ
            canFlip = false; // �ø� �� ��� ���·� ����
            Invoke("ResetCanFlip", flipWaitTime); // ��� �ð� �� �ٽ� �ø� �����ϵ��� ����
        }
    }

    private void ResetCanFlip()
    {
        canFlip = true; // ���� ���� ��ȯ ����
        SetRandomFlipWaitTime(); // ���� ��� �ð� ����
    }

    private void SetRandomFlipWaitTime()
    {
        flipWaitTime = UnityEngine.Random.Range(1f, 3f); // 1~3�� ������ ���� �ð� ����
    }

    private void Jump()
    {
        if (!isJumped)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetInteger("WalkSpeed", 1); // Jump �ִϸ��̼����� ����
            isJumped = true;
        }
    }

}
