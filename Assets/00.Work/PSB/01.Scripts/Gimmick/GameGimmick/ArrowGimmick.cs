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
    public override bool Check()
    {
        return true;
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)  //Player Layer
        {
            player.SetActive(false);
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

    private void OnDrawGizmos()
    {
        if (player != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, distanceValue);
        }
    }

}
