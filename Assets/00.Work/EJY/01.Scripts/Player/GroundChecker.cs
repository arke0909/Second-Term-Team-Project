using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private Vector2 _checkerSize;
    [SerializeField] private LayerMask _whatIsGround;

    public NotifyValue<bool> IsGround = new NotifyValue<bool>();

    public void GroundCheck()
    {
        IsGround.Value = Physics2D.OverlapBox(transform.position, _checkerSize, 0, _whatIsGround) != null;
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
        Gizmos.color = Color.white;
    }

    public void Initialize(Player player)
    {
    }
}
