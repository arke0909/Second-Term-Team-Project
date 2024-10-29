using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DetectGimmick : Gimmick
{
    protected GimmickDetector _detcter;

    protected virtual void Awake()
    {
        _detcter = GetComponent<GimmickDetector>();
    }

    public override bool Check()
    {
        return true;
    }
}
