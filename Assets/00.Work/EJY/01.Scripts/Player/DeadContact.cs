using System.Collections;
using UnityEngine;

public class DeadContact : MonoBehaviour
{
    [SerializeField] private SceneManageSO _scene = default;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Kill(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Kill(collision.collider);
    }

    private void Kill(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DeadInteraction deadInteraction))
        {
            StartCoroutine(DeadEvent(deadInteraction));
        }
    }

    private IEnumerator DeadEvent(DeadInteraction deadInteraction)
    {
        deadInteraction?.DeadEvent?.Invoke();
        yield return new WaitForSeconds(1);
        _scene.SceneReload(SceneManageSO.CurrentSceneName);
    }
}
