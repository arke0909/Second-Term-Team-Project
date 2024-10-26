using UnityEngine;
using DG.Tweening;

public class Platform : Gimmick
{
    [SerializeField] private float _endValue;
    [SerializeField] private float _duration;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _whatIsPlayer;

    public override void EffectGimmick()
    {
        transform.DOMoveX(transform.position.x + _endValue, _duration).SetLoops(1,LoopType.Yoyo);
    }

    public override bool Check()
    {
        Collider2D checkPlayer = Physics2D.OverlapCircle(transform.position, _radius, _whatIsPlayer);
        return checkPlayer;
    }

    public override void Initialzie()
    {
    }
}
