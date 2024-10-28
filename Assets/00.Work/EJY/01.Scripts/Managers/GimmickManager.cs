using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GimmickManager : Monosingleton<GimmickManager>
{
    [SerializeField] private GimmickDataListSO _gimmickList;


    protected override void Awake()
    {
        base.Awake();
        Initialize();
        SetGimmick();
    }

    private void Initialize()
    {
        foreach (var item in _gimmickList.list)
        {
            if (item.type == GimmickType.EnableCompo)
            {
                GameObject prefab = Instantiate(item.gimmickPrefab.gameObject);
            }
            else if(item is IInitializable init)
            {
                init.Initialize();
            }
            else
                continue;
        }
    }

    private void SetGimmick()
    {
        int gimmcikNum = Random.Range(0, _gimmickList.list.Count);

        _gimmickList.list[gimmcikNum].Activate();
    }
}
