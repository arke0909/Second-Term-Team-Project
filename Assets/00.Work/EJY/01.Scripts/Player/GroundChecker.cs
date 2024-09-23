using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Vector2 _checkerSize;
    [SerializeField] private LayerMask _whatIsGround;

    public bool IsGround { get; private set; } = false;

    public bool GroundCheck()
    {
        IsGround = Physics2D.OverlapBox(transform.position, _checkerSize, 0, _whatIsGround);
        return IsGround;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
        Gizmos.color = Color.white;
    }
}
