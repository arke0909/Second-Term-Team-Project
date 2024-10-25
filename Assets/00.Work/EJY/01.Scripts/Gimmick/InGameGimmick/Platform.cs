using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : Gimmick
{
    [SerializeField] private float _endValue;
    [SerializeField] private float _duration;

    public override void EffectGimmick()
    {
        transform.DOMoveX(transform.position.x + _endValue, _duration).SetLoops(1,LoopType.Yoyo);
    }

    public override bool Check()
    {
        return true;
    }

    public override void Initialzie()
    {
    }
}
