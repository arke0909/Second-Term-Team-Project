using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NiddleGimmick : Gimmick, Unity.VisualScripting.IInitializable
{
    [SerializeField] private GameObject gimmick;
    [SerializeField] private BoxCollider2D box2D;
    private bool isRun = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && isRun == false)
        {
            gimmick.transform.DOMoveX(gimmick.transform.position.x + 4, 0.5f).SetLoops(2, LoopType.Yoyo);
            isRun = true;
            box2D.enabled = false;
        }
    }

    public override bool Check()
    {
        return isRun;
    }

    public void Initialize()
    {
        box2D = GetComponent<BoxCollider2D>();
        gimmick = GetComponentInParent<GameObject>();
    }
}
