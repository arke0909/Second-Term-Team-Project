using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GimmickManager : Monosingleton<GimmickManager>
{
    [Header("Å¬¸®¾î È½¼ö")]
    [SerializeField] private int _maxClearCount = 0;

    [SerializeField] private GimmickDataListSO _gimmickList;

    public int ClearCount { get; private set; } = 0;

    protected override void Awake()
    {
        base.Awake();
        Initialize();
        SetGimmick();

        if (ClearCount >= _maxClearCount)
            SceneManager.LoadScene("Test");
    }

    private void Initialize()
    {
        foreach (var item in _gimmickList.list)
        {
            if (item.type == GimmickType.EnableCompo)
            {
                GameObject prefab = Instantiate(item.gimmickPrefab.gameObject);
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

    public void Clear()
    {
        ClearCount++;
    }

    public void CountReset()
    {
        ClearCount = 0;
    }
}
