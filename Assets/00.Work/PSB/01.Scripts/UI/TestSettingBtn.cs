using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSettingBtn : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    Vector2 v2 = new Vector2(1f, 0.5f);


    private void Start()
    {
        panel.transform.localScale = Vector2.zero;
    }

    private void OnDistroy()
    {
        DOTween.KillAll();
        Debug.Log(111);
    }

    public void Open()
    {
        panel.transform.localScale = Vector2.one;
        //panel.transform.DOScale(v2, 0.8f);
        Debug.Log("Y");
    }

    public void Close()
    {
        panel.transform.localScale = Vector2.zero;
        //panel.transform.DOScale(Vector2.zero, 1f).SetEase(Ease.InBack);
        Debug.Log("N");
    }

}
