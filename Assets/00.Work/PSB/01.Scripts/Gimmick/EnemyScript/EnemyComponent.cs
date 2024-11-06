using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected Animator anim;
    [SerializeField] protected SpriteRenderer sprite;
    protected EnemyMove enemyMove;
    [Header("Player")]
    [SerializeField] protected GameObject player;
    [SerializeField] protected Rigidbody2D playerRB;
    [Header("Value")]
    public int nextMove;
    public int speed = 4;
    public float _jumpPower = 6f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        enemyMove = GetComponentInParent<EnemyMove>();
    }
}
