using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : DetectGimmick
{
    /*
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer sprite;
    float nextMove;
    int speed;
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
    
    */

    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float flipDelay = 0.5f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D _rb;
    private Collider2D _collider; 
    private bool _isFlipped = false;
    private bool _isJumping = false;
    private float _nextFlipTime;
    private Animator _animator;

    private GimmickDetector _detector;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _detector = GetComponent<GimmickDetector>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        ScheduleNextFlip();
    }

    private void Update()
    {
        UpdateColliderPosition(); 

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

        UpdateAnimationStates();
    }

    private void Jump()
    {
        if (_rb != null)
        {
            _isJumping = true;
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _animator.SetBool("IsJumping", true);
            _animator.SetBool("IsIdle", false); 
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
        if (_collider != null)
        {
            Vector3 colliderPosition = transform.position;
            _collider.transform.position = colliderPosition;
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
                _isJumping = false; 
            }
            else if (_isJumping == false && _rb.velocity.y < 0)
            {
                // 점프 중 아래로 떨어질 때
                _animator.SetBool("IsFalling", true); 
                _animator.SetBool("IsIdle", false);
                _animator.SetBool("IsJumping", false);
            }
            else
            {
                _animator.SetBool("IsIdle", true); 
                _animator.SetBool("IsJumping", false);
                _animator.SetBool("IsFalling", false);
            }
        }
        else if (_rb.velocity.y < 0)
        {
            _animator.SetBool("IsFalling", true);
            _animator.SetBool("IsIdle", false);
            _animator.SetBool("IsJumping", false);
        }
    }


}
