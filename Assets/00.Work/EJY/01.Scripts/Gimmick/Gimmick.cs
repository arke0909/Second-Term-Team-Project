using UnityEngine;

public abstract class Gimmick : MonoBehaviour
{
    public virtual bool ActivatedGimmcik()
    {
        return true;
    }

    public abstract void EffectGimmick();
}
