using GGMPool;
using UnityEngine;

public class EffectFeedback : Feedback
{
    [SerializeField] private PoolTypeSO _poolType;
    [SerializeField] private PoolManagerSO _poolManager;
    public override void PlayFeedback()
    {
        EffectPlayer effect = _poolManager.Pop(_poolType) as EffectPlayer;
        effect.SetPositionAndPlay(transform.position);
    }

    public override void StopFeedback()
    {
    }
}
