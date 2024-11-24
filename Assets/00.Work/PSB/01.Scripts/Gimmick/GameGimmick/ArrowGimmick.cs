using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowGimmick : Gimmick, IIntializable
{
    [Header("Player")]
    [SerializeField] private GameObject player;
    [Header("Collider")]
    [SerializeField] private Collider2D objCollider;
    [Header("Sprite")]
    [SerializeField] private SpriteRenderer head;
    [SerializeField] private SpriteRenderer body;

    [Header("Value")]
    public float distanceValue = 10f;
    public float arrowSpeed = 5f;
    private Vector2 direction;

    private bool isMove = false;

    protected GimmickDetector _detcter;

    protected virtual void Awake()
    {
        _detcter = GetComponent<GimmickDetector>();
    }

    public override bool Check()
    {
        return _detcter.CheckPlayer();
    }
    public void Initialzie()
    {
        objCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        float distancePlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distancePlayer < distanceValue && !isMove)
        {
            head.enabled = true;
            body.enabled = true;
            StartMove();
        }
        else if (distancePlayer > distanceValue)
        {
            head.enabled = false;
            body.enabled = false;
            isMove = false;
        }

        if (isMove == true)
        {
            MoveArrow();
        }

    }


    private void StartMove()
    {
        Vector2 direct = (player.transform.position - transform.position).normalized;
        transform.up = direct;

        direction = (player.transform.position - transform.position).normalized;
        isMove = true;
    }

    private void MoveArrow()
    {
        transform.position += (Vector3)direction * arrowSpeed * Time.deltaTime;
    }
}
