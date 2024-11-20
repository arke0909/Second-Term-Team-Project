using UnityEngine;

public class PlatformGround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
