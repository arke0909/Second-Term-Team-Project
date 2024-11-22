using System;
using System.Collections;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private BoolEventChannelSO _fadeEvent;
    [SerializeField] private SceneManageSO _sceneManage;
    [SerializeField] private string _endSceneName;
    private bool isEnd = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnd == false)
        {
            if (collision.TryGetComponent(out PlayerMovement playerMove))
            {
                playerMove.canMove = false;
                isEnd = true;
                StartCoroutine(EndCoroutine());
                _fadeEvent.RaiseEvent(false);
            }
        }
    }

    private IEnumerator EndCoroutine()
    {
        _fadeEvent.RaiseEvent(false);
        yield return new WaitForSeconds(1.2f);
        _sceneManage.SceneLoad(_endSceneName);
    }
}
