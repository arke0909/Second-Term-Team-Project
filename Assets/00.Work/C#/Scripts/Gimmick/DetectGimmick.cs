using UnityEngine;

[RequireComponent(typeof(GimmickDetector))]
public abstract class DetectGimmick : Gimmick
{
    protected GimmickDetector _detcter;

    protected virtual void Awake()
    {
        _detcter = GetComponent<GimmickDetector>();
    }

    public override bool Check()
    {
        return false;
    }
}
