using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFallGimmick : Gimmick, IInitializable
{
    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D playerRb;
    [Header("Prefabs")]
    [SerializeField] private GameObject rockGimmickPrefab;
    [SerializeField] private GameObject rockGrid;
    [SerializeField] private Rigidbody2D gridRb;
    [Header("Gizmos")]
    public Vector2 range = new Vector2(5f, 5f);

    public void Initialze()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rockGrid = GameObject.FindGameObjectWithTag("FallObject");

        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody2D>();
        }
        if (rockGrid != null)
        {
            gridRb = rockGrid.GetComponent<Rigidbody2D>();
        }

        gridRb.gravityScale = 0f;
    }

    public override bool Check()
    {
        return true;
    }

    public override void EffectGimmick()
    {
        if (IsPlayerInRange())
        {
            gridRb.gravityScale = 3f;
        }
        //base.EffectGimmick();
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
