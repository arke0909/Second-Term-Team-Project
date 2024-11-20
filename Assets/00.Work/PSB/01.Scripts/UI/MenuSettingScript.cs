using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettingScript : MonoBehaviour
{
    //¤Ç¤Ç
    /*[SerializeField] private GameObject panel;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button exitBtn;
    Vector2 v2 = new Vector2(1f, 1f);

    private void Start()
    {
        settingBtn.onClick.AddListener(Open);
        exitBtn.onClick.AddListener(Close);
        DOTween.Init();
        panel.transform.localScale = Vector2.zero;
        panel.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Open()
    {
        panel.transform.localScale = Vector2.one;
        Debug.Log("Y");
    }

    public void Close()
    {
        panel.transform.localScale = Vector2.zero;
        Debug.Log("N");
    }
    */

    //¼±¹è´Ô °Å
    [SerializeField] private Button _joinBtn;
    [SerializeField] private Button _closeBtn;

    private RectTransform _rectTrm;
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        Debug.Log($"Time : {Time.timeScale}");
        //Time.timeScale = 1f;
        CloseWindow();
    }

    private void Awake()
    {
        _rectTrm = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();

        _joinBtn.onClick.AddListener(OpenWindow);
        _closeBtn.onClick.AddListener(CloseWindow);
    }

    public void OpenWindow()
    {
        Sequence seq = DOTween.Sequence().SetAutoKill(false).SetUpdate(true);
        seq.OnStart(() => _canvasGroup.alpha = 1f);
        seq.Append(_rectTrm.DOAnchorPosY(0, 0.8f));
        seq.AppendCallback(() =>
        {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        });
    }

    private void CloseWindow()
    {
        float screenHeight = Screen.height;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        Sequence seq = DOTween.Sequence().SetAutoKill(false).SetUpdate(true);
        seq.Append(_rectTrm.DOAnchorPosY(screenHeight, 0.8f));
        seq.OnComplete(() => _canvasGroup.alpha = 0f);
    }

}
