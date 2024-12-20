using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;

    private Player _player;
    private InputReaderSO _input;
    private PlayerAnimation _animation;
    public Rigidbody2D RbCompo { get; private set; }

    public float timeInAir;
    public float extraGravity = 20f, gravityDelay = 0.15f;

    public bool canMove;

    public void Initialize(Player player)
    {
        _player = player;
        canMove = true;
        RbCompo = GetComponent<Rigidbody2D>();
        _input = _player.GetCompo<InputReaderSO>();
        _animation = _player.GetCompo<PlayerAnimation>();
    }

    public void Stop(bool isYAxis = false)
    {
        if (!isYAxis)
        {
            RbCompo.velocity = new Vector2(0, RbCompo.velocity.y);
        }
        else
            RbCompo.velocity = Vector2.zero;
    }

    public void Movement()
    {
        if (canMove)
        {
            Vector2 moveDir = _input.MoveDir;
            RbCompo.velocity = new Vector2(moveDir.x * _moveSpeed, RbCompo.velocity.y);
            _animation.FlipController(moveDir.x);
        }
    }

    public void Jump()
    {
        RbCompo.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        Debug.Log(_jumpPower);
    }
}