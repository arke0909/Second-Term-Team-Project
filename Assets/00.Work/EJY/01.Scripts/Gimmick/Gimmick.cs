using UnityEngine;

public abstract class Gimmick : MonoBehaviour
{
    public Transform spawnTrm;
    public virtual bool ActivatedGimmcik()
    {
        return true;
    }

    public abstract void EffectGimmick();
}
