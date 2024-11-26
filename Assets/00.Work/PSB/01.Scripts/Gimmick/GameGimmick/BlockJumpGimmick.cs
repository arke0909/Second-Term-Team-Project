using UnityEngine;

public class BlockJumpGimmick : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private PlayerMovement playerMovement;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            playerMovement = player.GetCompo<PlayerMovement>();

            player.StateMachine.ChangeState(PlayerStateEnum.Jump);
            playerMovement.Stop(true);
            playerMovement.RbCompo.AddForce(new Vector2(playerMovement.RbCompo.velocity.x, jumpForce), ForceMode2D.Impulse);
        }
    }
}
