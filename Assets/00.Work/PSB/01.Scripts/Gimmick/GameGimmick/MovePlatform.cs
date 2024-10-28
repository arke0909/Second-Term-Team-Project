using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : Gimmick, IIntializable
{
    [Header("Value")]
    [SerializeField] private float _value;
    [SerializeField] private float _duration;
    private bool _isEnd = false;

    public override void EffectGimmick()
    {
        if (_isEnd == false)
        {
            transform.DOMoveX(transform.position.x + _value, _duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            _isEnd = true;
        }
        base.EffectGimmick();
    }

    public override bool Check()
    {
        return true;
    }

    public void Initialzie()
    {
        _isEnd = false;
    }
}
