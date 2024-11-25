using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockJumpGimmick : MonoBehaviour
{
    [SerializeField] private Vector2 jumpForce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigid))
        {
            jumpForce.x = rigid.velocity.x;
            rigid.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }
}
