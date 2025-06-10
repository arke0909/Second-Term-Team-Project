using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectScript : MonoBehaviour
{
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _closeBtn;
    [SerializeField] private Button hardBtn;
    [SerializeField] private Button nrmalBtn;

    [SerializeField] private CanvasGroup _canvasGroup;
    private RectTransform _rectTrm;

    public string normalSceneName;
    public string hardSceneName;

    private void Start()
    {
        CloseWindow();
    }

    private void Awake()
    {
        _rectTrm = GetComponent<RectTransform>();

        _startBtn.onClick.AddListener(OpenWindow);
        _closeBtn.onClick.AddListener(CloseWindow);
        hardBtn.onClick.AddListener(HardClick);
        nrmalBtn.onClick.AddListener(NormalClick);
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

    public void CloseWindow()
    {
        float screenHeight = Screen.height;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        Sequence seq = DOTween.Sequence().SetAutoKill(false).SetUpdate(true);
        seq.Append(_rectTrm.DOAnchorPosY(screenHeight, 0.8f));
    }

    public void NormalClick()
    {
        SceneManager.LoadScene(normalSceneName);
    }

    public void HardClick()
    {
        SceneManager.LoadScene(hardSceneName);
    }

}
