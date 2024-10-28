using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements.Experimental;

public class Platform : Gimmick
{
    [SerializeField] private float _endValue;
    [SerializeField] private float _duration;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _whatIsPlayer;

    public override void EffectGimmick()
    {
        transform.DOMoveX(transform.position.x + _endValue, _duration)
            .SetLoops(1,LoopType.Yoyo)
            .SetEase(Ease.Linear);

        base.EffectGimmick();
    }

    public override bool Check()
    {
        Collider2D checkPlayer = Physics2D.OverlapCircle(transform.position, _radius, _whatIsPlayer);
        return checkPlayer;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
