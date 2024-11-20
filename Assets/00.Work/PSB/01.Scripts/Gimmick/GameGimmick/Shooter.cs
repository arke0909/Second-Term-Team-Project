using UnityEngine;

public class Shooter : DetectGimmick
{
    [SerializeField] private float _shotPower = 5f;
    [SerializeField] private bool _isUp;

    private Rigidbody2D _rigidCompo;

    protected override void Awake()
    {
        base.Awake();
        _rigidCompo = GetComponent<Rigidbody2D>();
        _rigidCompo.velocity = Vector2.zero;
    }

    public override bool Check()
    {
        return _detcter.CheckPlayer();
    }

    public override void EffectGimmick()
    {
        Fire(_isUp);

        base.EffectGimmick();
    }

    private void Fire(bool isUp = false)
    {
        Vector2 shotDir = isUp ? Vector2.up : Vector2.down;

        _rigidCompo.velocity = shotDir * _shotPower;

        Debug.Log(1);
    }
}
