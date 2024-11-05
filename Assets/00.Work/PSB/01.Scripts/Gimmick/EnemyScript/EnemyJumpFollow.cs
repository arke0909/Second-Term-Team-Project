using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpFollow : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D playerRB;
    [Header("GameObject")]
    [SerializeField] private Rigidbody2D myRB;
    [Header("Value")]
    [SerializeField] private float _jumpPower = 9f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        myRB = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (IsPlayerJumping())
            {
                myRB.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            }
        }

    }

    private bool IsPlayerJumping()
    {
        return playerRB.velocity.y > 0;
    }


}
