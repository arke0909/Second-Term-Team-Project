using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RiseBlockGimmick : Gimmick, Unity.VisualScripting.IInitializable
{
    [Header("Gimmick")]
    [SerializeField] private GameObject gimmick;
    [SerializeField] private Rigidbody2D rb;
    [Header("Collider")]
    [SerializeField] private BoxCollider2D boxCollider;

    public override bool Check()
    {
        return true;
    }

    public void Initialize()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            //gimmick.transform.DOMoveY(gimmick.transform.position.y + 10, 0.4f).SetEase(Ease.Linear);
            rb.gravityScale = -5f;
            boxCollider.enabled = false;
        }
    }

}
