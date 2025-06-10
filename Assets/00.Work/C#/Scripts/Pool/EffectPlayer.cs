using GGMPool;
using System.Collections;
using UnityEngine;

public class EffectPlayer : MonoBehaviour, IPoolable
{
    [SerializeField] private PoolTypeSO _poolType;
    [SerializeField] private PoolManagerSO _poolManager;

    private Pool _pool;
    private ParticleSystem _particle;
    private float _duration;

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
        _duration = _particle.main.duration;
    }

    public PoolTypeSO PoolType => _poolType;

    public GameObject GameObject => gameObject;

    public void SetPositionAndPlay(Vector3 position)
    {
        transform.position = position;
        _particle.Play();
        StartCoroutine(DelayAndGotoPoolCoroutine());
    }

    private IEnumerator DelayAndGotoPoolCoroutine()
    {
        yield return new WaitForSeconds(_duration);
        _poolManager.Push(this);
    }

    public void ResetItem()
    {
        _particle.Stop();
        _particle.Simulate(0);
    }

    public void SetUpPool(Pool pool)
    {
        _pool = pool;
    }
}
