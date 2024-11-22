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

    public float speed = 2f; // 이동 속도
    public float jumpPower = 5f; // 점프 힘
    private float nextMove; // 다음 이동 방향
    private bool isJumped = false; // 점프 상태
    private float flipWaitTime; // 방향 전환 대기 시간
    private bool canFlip = true; // 방향 전환 가능 여부

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        StartMovement();
        SetRandomFlipWaitTime(); // 초기 방향 전환 대기 시간 설정
    }

    private void FixedUpdate()
    {
        Move();

        // 벽 감지 및 방향 전환
        if (IsOnWall() && canFlip)
        {
            FlipDirection();
        }

        // speed가 0일 때 점프 애니메이션 실행
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
        anim.SetInteger("WalkSpeed", (int)nextMove); // 이동 중에는 Idle 애니메이션 사용
    }

    private bool IsOnWall()
    {
        // 앞쪽에 벽이 있는지 감지
        Vector2 frontVect = new Vector2(rigid.position.x + nextMove * 0.5f, rigid.position.y);
        RaycastHit2D hit = Physics2D.Raycast(frontVect, Vector2.right * Mathf.Sign(nextMove), 0.1f, LayerMask.GetMask("Ground"));
        return hit.collider != null; // 벽이 있으면 true 반환
    }

    private void FlipDirection()
    {
        if (canFlip)
        {
            nextMove *= -1; // 이동 방향 반전
            sprite.flipX = nextMove < 0; // 방향에 따라 스프라이트 반전
            isJumped = false; // 점프 상태 초기화
            canFlip = false; // 플립 후 대기 상태로 변경
            Invoke("ResetCanFlip", flipWaitTime); // 대기 시간 후 다시 플립 가능하도록 설정
        }
    }

    private void ResetCanFlip()
    {
        canFlip = true; // 다음 방향 전환 가능
        SetRandomFlipWaitTime(); // 다음 대기 시간 설정
    }

    private void SetRandomFlipWaitTime()
    {
        flipWaitTime = UnityEngine.Random.Range(1f, 3f); // 1~3초 사이의 랜덤 시간 설정
    }

    private void Jump()
    {
        if (!isJumped)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetInteger("WalkSpeed", 1); // Jump 애니메이션으로 설정
            isJumped = true;
        }
    }

}
