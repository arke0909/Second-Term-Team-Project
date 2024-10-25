using UnityEngine;

public enum GimmickType
{
    Instantiate, EnableCompo, None
}

[CreateAssetMenu(menuName = "SO/Gimmick/DataSO")]
public class GimmickDataSO : ScriptableObject
{
    public GimmickType type;
    public Gimmick gimmickPrefab;

    public void Activate()
    {
        switch(type)
        {
            case GimmickType.EnableCompo:
                gimmickPrefab.enabled = true;
                break;
            case GimmickType.Instantiate:
                GameObject gimmickObject = GameObject.Instantiate(gimmickPrefab.gameObject);
                break;
            default:
                break;
        }
        
    }
}
