using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private BoolEventChannelSO _fadeEventChannel;

    private void Start()
    {
        _fadeEventChannel.RaiseEvent(true);
    }
}
