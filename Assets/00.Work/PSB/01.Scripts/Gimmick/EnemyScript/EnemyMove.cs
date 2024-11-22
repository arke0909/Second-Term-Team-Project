using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : DetectGimmick
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


    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float flipDelay = 0.5f;
    [SerializeField] private float cliffCheckDistance = 1f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D _rb;
    private Collider2D _collider; // Collider2D �߰�
    private bool _isFlipped = false;
    private bool _isJumping = false;
    private float _nextFlipTime;
    private Animator _animator;

    private GimmickDetector _detector;

    private void Awake()
    {
        base.Awake();
        _rb = GetComponent<Rigidbody2D>();
        _detector = GetComponent<GimmickDetector>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>(); // Collider2D ������Ʈ ��������
        ScheduleNextFlip();
    }

    private void Update()
    {
        UpdateColliderPosition(); // �ݶ��̴� ��ġ ������Ʈ

        if (_detector.CheckPlayer())
        {
            if (IsGrounded() && !_isJumping)
            {
                Jump();
            }
        }
        else
        {
            MoveRandomly();
            if (Time.time >= _nextFlipTime)
            {
                Flip();
                ScheduleNextFlip();
            }
        }

        // �ִϸ��̼� ���� ������Ʈ
        UpdateAnimationStates();
    }

    private void Jump()
    {
        if (_rb != null)
        {
            _isJumping = true;
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _animator.SetBool("IsJumping", true); // ���� �ִϸ��̼� ����
            _animator.SetBool("IsIdle", false); // Idle �ִϸ��̼� ����
            StartCoroutine(FlipCoroutine());
        }
    }

    private void MoveRandomly()
    {
        float moveDirection = _isFlipped ? -1 : 1;
        _rb.velocity = new Vector2(moveDirection * moveSpeed, _rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return _rb.IsTouchingLayers(groundLayer);
    }

    private void Flip()
    {
        _isFlipped = !_isFlipped;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private IEnumerator FlipCoroutine()
    {
        yield return new WaitForSeconds(flipDelay);
    }

    private void ScheduleNextFlip()
    {
        _nextFlipTime = Time.time + UnityEngine.Random.Range(1f, 3f);
    }

    private void UpdateColliderPosition()
    {
        // �ݶ��̴��� ��������Ʈ�� �߽ɿ� ���߱�
        if (_collider != null)
        {
            Vector3 colliderPosition = transform.position; // ���� ������Ʈ�� ��ġ
            _collider.transform.position = colliderPosition; // �ݶ��̴� ��ġ ������Ʈ
        }
    }

    private void UpdateAnimationStates()
    {
        if (IsGrounded())
        {
            if (_isJumping)
            {
                _animator.SetBool("IsJumping", true);
                _animator.SetBool("IsIdle", false);
                _animator.SetBool("IsFalling", false);
                _isJumping = false; // Jump ���� ����
            }
            else if (_isJumping == false && _rb.velocity.y < 0)
            {
                // ���� �� �Ʒ��� ������ ��
                _animator.SetBool("IsFalling", true); // ������ �ִϸ��̼� ����
                _animator.SetBool("IsIdle", false);
                _animator.SetBool("IsJumping", false);
            }
            else
            {
                _animator.SetBool("IsIdle", true); // Idle ���·� ��ȯ
                _animator.SetBool("IsJumping", false);
                _animator.SetBool("IsFalling", false);
            }
        }
        else if (_rb.velocity.y < 0)
        {
            _animator.SetBool("IsFalling", true); // ������ �ִϸ��̼� ����
            _animator.SetBool("IsIdle", false);
            _animator.SetBool("IsJumping", false);
        }
    }


}
