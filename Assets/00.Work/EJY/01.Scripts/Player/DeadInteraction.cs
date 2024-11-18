using UnityEngine;
using UnityEngine.Events;

public class DeadInteraction : MonoBehaviour
{
    [SerializeField] private BoolEventChannelSO _fadeEvent;

    public UnityEvent DeadEvent;

    public void PlayerDead() => gameObject.SetActive(false);

    public void Fade(bool isFadin) => _fadeEvent.RaiseEvent(isFadin);
}
