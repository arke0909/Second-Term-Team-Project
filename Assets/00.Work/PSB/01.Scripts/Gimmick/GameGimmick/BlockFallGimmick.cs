using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFallGimmick : Gimmick, IIntializable
{
    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D playerRb;
    [Header("Prefabs")]
    [SerializeField] private GameObject fallBlocckPrefab;
    [SerializeField] private GameObject grid;
    [SerializeField] private Rigidbody2D gridRb;
    [Header("Value")]
    private bool isFalled = false;
    [Header("Gizmos")]
    public Vector2 range = new Vector2(5f, 5f);

    public void Initialzie()
    {
        isFalled = false;

        player = GameObject.FindGameObjectWithTag("Player");
        grid = GameObject.FindGameObjectWithTag("FallObject");
        
        if (player != null)
            playerRb = player.GetComponent<Rigidbody2D>();
        if (grid != null)
            gridRb = grid.GetComponent<Rigidbody2D>();

        gridRb.gravityScale = 0f;
    }

    public override bool Check()
    {
        return true;
    }

    public override void EffectGimmick()
    {
        base.EffectGimmick();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gridRb.gravityScale = 4f;
            isFalled = true;
        }
    }

    private bool IsPlayerInRange()
    {
        if (playerRb != null)
        {
            Vector2 playerPosition = playerRb.position;
            Vector2 center = (Vector2)transform.position;
            return playerPosition.x >= center.x - range.x / 2 &&
                   playerPosition.x <= center.x + range.x / 2 &&
                   playerPosition.y >= center.y - range.y / 2 &&
                   playerPosition.y <= center.y + range.y / 2;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector2 gizmoPosition = (Vector2)transform.position;
        Gizmos.DrawWireCube(transform.position, new Vector3(range.x, range.y, 1f));
    }

}
