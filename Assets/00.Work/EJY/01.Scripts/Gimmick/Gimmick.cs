using UnityEngine;

public abstract class Gimmick : MonoBehaviour
{
    protected bool used = false;
    private void Update()
    {
        if(Check() && used == false)
            EffectGimmick();
    }

    public abstract void Initialzie();

    public abstract bool Check();

    public virtual void EffectGimmick()
    {
        used = true;
    }
}
