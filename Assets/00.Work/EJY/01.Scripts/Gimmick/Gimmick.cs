using System;
using UnityEngine;

public abstract class Gimmick : MonoBehaviour
{
    protected bool used = false;
    private void Update()
    {
        if (Check() && used == false)
            EffectGimmick();
    }

    public abstract bool Check();

    public virtual void EffectGimmick()
    {
        try
        {
            used = true;
            Debug.Log(1);
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
