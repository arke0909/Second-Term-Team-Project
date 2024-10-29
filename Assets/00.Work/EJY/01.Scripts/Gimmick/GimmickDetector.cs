using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GimmickDetector : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _whatIsPlayer;

    public bool CheckWhithOverlapBox()
    {
        Collider2D checkPlayer = Physics2D.OverlapCircle(transform.position, _range, _whatIsPlayer);
        return checkPlayer;
    }
}
