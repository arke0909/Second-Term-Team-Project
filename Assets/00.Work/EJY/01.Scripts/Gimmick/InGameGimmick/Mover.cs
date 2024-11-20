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
        SetXY();
    }

    private void SetXY()
    {
        switch (_moveXY)
        {
            case MoveXY.X:
                _moveTween = transform.DOMoveX(transform.position.x + _endValue, _duration).SetLoops(_loopCnt, _loopType).SetEase(_ease).Pause();
                break;
            case MoveXY.Y:
                _moveTween = transform.DOMoveY(transform.position.y + _endValue, _duration).SetLoops(_loopCnt, _loopType).SetEase(_ease).Pause();
                break;
        }
    }

    public override void EffectGimmick()
    {
        _moveTween.Play();

        base.EffectGimmick();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _moveTween.Complete();
    }

    public override bool Check()
    {
        return _detcter.CheckPlayer();
    }
}
