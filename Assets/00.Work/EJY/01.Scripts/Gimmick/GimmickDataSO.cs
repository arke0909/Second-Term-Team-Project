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
}
