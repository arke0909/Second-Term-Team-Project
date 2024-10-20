using UnityEngine;

public enum GimmickType
{
    Prefab, None
}

[CreateAssetMenu(menuName = "SO/Gimmick/DataSO")]
public class GimmickDataSO : ScriptableObject
{
    public GameObject originObject;
    public Gimmick gimmickPrefab;
}
