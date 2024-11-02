using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveGroundGimmick : Gimmick, IInitializable
{
    [SerializeField] private GameObject gimmick;
    [SerializeField] private BoxCollider2D box2D;
    private bool isRun = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && isRun == false)
        {
            gimmick.transform.DOMoveX(gimmick.transform.position.x + 4, 0.1f).SetEase(Ease.Linear);
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
