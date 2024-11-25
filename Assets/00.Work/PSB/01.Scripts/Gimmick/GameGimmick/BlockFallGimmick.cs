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
        _groundRigid.bodyType = RigidbodyType2D.Static;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            _groundRigid.bodyType = RigidbodyType2D.Dynamic;
            _groundRigid.gravityScale = 1.2f;
            _used = true;
    }

    private void Update()
    {
        if (!_used) return;

        _currentLifeTime += Time.deltaTime;

        if(_currentLifeTime >= _lifeTime ) 
            gameObject.SetActive(false);
    }
}
