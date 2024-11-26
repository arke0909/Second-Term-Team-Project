using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    public Animator AnimaCompo { get; private set; }
    public float FacingDirection { get; private set; } = 1; //오른쪽이 1, 왼쪽이 -1

    public void Initialize(Player player)
    {
        _player = player;
        AnimaCompo = GetComponent<Animator>();
    }

    public void Flip()
    {
        FacingDirection *= -1;
        _player.transform.localScale = new Vector3(_player.transform.localScale.x * -1, 1, 1);
    }

    public void FlipController(float xMove)
    {
        if (Mathf.Abs(FacingDirection + xMove) < 0.5f)
            Flip();
    }
}
