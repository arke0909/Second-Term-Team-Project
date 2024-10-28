using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DeadContact : MonoBehaviour
{
    [SerializeField] private float _waitTime;
    [SerializeField] private float _power;

    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GameManager.Instance.player.GetCompo<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.player.IsDead)
        {

        StartCoroutine(DeadCoroutine());
        }
    }

    private IEnumerator DeadCoroutine()
    {
        _playerMovement.RbCompo.velocity = Vector2.zero;
        _playerMovement.RbCompo.gravityScale = 0;
        yield return new WaitForSeconds(_waitTime);
        _playerMovement.RbCompo.AddForce(Vector2.up * _power, ForceMode2D.Impulse);
        _playerMovement.RbCompo.gravityScale = 1;
        yield return new WaitForSeconds(_waitTime);
        //GameManager.Instance.Restart();
    }
}
