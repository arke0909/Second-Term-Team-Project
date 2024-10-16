using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMap : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D _playerCollider;


    private void Awake()
    {
        _playerCollider = GetComponentInChildren<CapsuleCollider2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NextMapBlock")
        {
            _playerCollider.transform.parent.position = new Vector3(_playerCollider.transform.position.x, _playerCollider.transform.position.y + 5,
                _playerCollider.transform.position.z);
            
        }
    }


}
