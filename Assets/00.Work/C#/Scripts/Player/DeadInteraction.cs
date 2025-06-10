using UnityEngine;
using UnityEngine.Events;

public class DeadInteraction : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private BoolEventChannelSO _fadeEvent;

    private Player _player;

    public UnityEvent DeadEvent;

    public void PlayerDead() => _player.SetDead();

    public void Fade(bool isFadin) => _fadeEvent.RaiseEvent(isFadin);

    public void Initialize(Player player)
    {
        _player = player;
    }
}
