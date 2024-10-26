using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGimmick : Gimmick
{
    [Header("Player")]
    public GameObject player;
    public GameObject grid;
    public Rigidbody2D playerRb;
    [Header("Prefabs")]
    public GameObject prefab;
    public float spawnHeight = 1f;
    [Header("Value")]
    private bool hasSpawned = false;
    [Header("Gizmos")]
    public Vector2 range = new Vector2(5f, 5f);


    public override void Initialzie()
    {
        hasSpawned = false;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody2D>();
        }
    }

    public override bool Check()
    {
        return true; 
    }

    public override void EffectGimmick()
    {
        if (hasSpawned == false && playerRb != null && playerRb.velocity.y > 0 && IsPlayerInRange())
        {
            Instantiate(prefab, transform.position + new Vector3(0, spawnHeight, 0), Quaternion.identity);
            hasSpawned = true;
            /*if (grid != null)
            {
                grid.SetActive(true);
            }*/
        }

    }

    /// <summary>
    /// 범위 내에 있는지를 체크하는 메서드
    /// </summary>
    /// <returns></returns>
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
