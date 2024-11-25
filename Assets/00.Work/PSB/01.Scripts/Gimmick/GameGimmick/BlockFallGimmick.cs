using UnityEngine;

public class BlockFallGimmick : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 15f;

    private float _currentLifeTime = 0;

    private Rigidbody2D _groundRigid;
    private bool _used;

    private void Awake()
    {
        _groundRigid = GetComponent<Rigidbody2D>();
        _groundRigid.gravityScale = 0;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        int collisionLayer = 1 << collision.gameObject.layer;
        if ((collisionLayer & gameObject.layer) != 0)
        {
            Debug.Log("¶³¾îÁü");
            _groundRigid.gravityScale = 1.2f;
        }
    }
}
