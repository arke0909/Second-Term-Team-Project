using System.Collections;
using UnityEngine;

public class DeadContact : MonoBehaviour
{
    [SerializeField] private SceneManageSO _scene = default;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Kill(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Kill(collision.gameObject);
    }

    private void Kill(GameObject collision)
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
        _scene.SceneLoad(SceneManageSO.CurrentSceneName.GetHashCode());
    }
}
