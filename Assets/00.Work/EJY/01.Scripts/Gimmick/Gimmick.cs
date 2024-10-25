using UnityEngine;

public abstract class Gimmick : MonoBehaviour
{
    private void Update()
    {
        if(Check())
            EffectGimmick();
    }

    public abstract void Initialzie();

    public abstract bool Check();

    public abstract void EffectGimmick();
}
