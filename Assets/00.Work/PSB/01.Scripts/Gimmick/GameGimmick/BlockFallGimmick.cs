using UnityEngine;

public class BlockFallGimmick : MonoBehaviour
{
    private Rigidbody2D _groundRigid;

    private void Awake()
    {
        _groundRigid = GetComponent<Rigidbody2D>();
        _groundRigid.gravityScale = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _groundRigid.gravityScale = 1.2f;
    }
}
