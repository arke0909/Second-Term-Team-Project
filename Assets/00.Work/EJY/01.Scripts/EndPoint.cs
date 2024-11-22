using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private BoolEventChannelSO _fadeEvent;
    [SerializeField] private SceneManageSO _sceneManage;

    private bool isEnd = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnd == false)
        {
            if (collision.TryGetComponent(out PlayerMovement playerMove))
            {
                playerMove.canMove = false;
                isEnd = true;
                _fadeEvent.RaiseEvent(false);
            }
        }
    }
}
