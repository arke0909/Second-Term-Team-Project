using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private Vector2 _checkerSize;
    [SerializeField] private LayerMask _whatIsGround;

    public bool IsGround { get; private set; } = false;

    public void GroundCheck()
    {
        IsGround = Physics2D.OverlapBox(transform.position, _checkerSize, 0, _whatIsGround) != null;
    }

    public void Initialize(Player player)
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
        Gizmos.color = Color.white;
    }
}
