using UnityEngine;
using DG.Tweening;
using System;

public class Mover : DetectGimmick
{
    [Serializable]
    public enum MoveXY
    {
        X, Y
    }
    [Header("TweenInfo")]
    [SerializeField] private MoveXY _moveXY;
    [SerializeField] private LoopType _loopType;
    [SerializeField] private Ease _ease;
    [SerializeField] private int _loopCnt;
    [SerializeField] private float _endValue;
    [SerializeField] private float _duration;

    private Tween _moveTween;

    protected override void Awake()
    {
        base.Awake();

        switch (_moveXY)
        {
            case MoveXY.X:
                transform.DOMoveX(transform.position.x + _endValue, _duration);
                break;
            case MoveXY.Y:
                transform.DOMoveY(transform.position.y + _endValue, _duration);
                break;
        }
    }

    public override void EffectGimmick()
    {
        _moveTween.SetLoops(_loopCnt, _loopType)
            .SetEase(_ease);

        base.EffectGimmick();
    }

    public override bool Check()
    {
        return _detcter.CheckWhithOverlapBox();
    }
}
