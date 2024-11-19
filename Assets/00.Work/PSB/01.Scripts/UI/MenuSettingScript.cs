using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettingScript : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button exitBtn;
    Vector2 v2 = new Vector2(1f, 1f);


    private void Start()
    {
        settingBtn.onClick.AddListener(Open);
        exitBtn.onClick.AddListener(Close);
        DOTween.Init();
        panel.transform.localScale = Vector2.zero;
    }

    private void OnDisable()
    {
        DOTween.KillAll();
        
    }


    public void Open()
    {
        if (panel.gameObject == null) return;
        DOTween.Init();
        //panel.transform.localScale = Vector2.one;
        panel.transform.DOScale(v2, 0.7f).OnComplete(() => Debug.Log("Open End"));
        Debug.Log("Y");
    }

    public void Close()
    {
        if (panel.gameObject == null) return;
        DOTween.Init();
        //panel.transform.localScale = Vector2.zero;
        panel.transform.DOScale(Vector2.zero, 1f).SetEase(Ease.InBack).OnComplete(() => Debug.Log("Close End")); ;
        Debug.Log("N");
    }

}
