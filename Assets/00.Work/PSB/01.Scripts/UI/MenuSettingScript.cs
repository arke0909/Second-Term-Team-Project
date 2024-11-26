using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettingScript : MonoBehaviour
{
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

    [SerializeField] private Button _joinBtn;
    [SerializeField] private Button _closeBtn;
    [SerializeField] private Button _audioSettingBtn;
    [SerializeField] private Button _fullscreenSettingBtn;

    [SerializeField] private RectTransform _fullscreenRectTrm;
    [SerializeField] private CanvasGroup _fullscreenGroup;

    [SerializeField] private CanvasGroup _canvasGroup;
    private RectTransform _rectTrm;

    private void Start()
    {
        CloseWindow();
        CloseScreenSetting();
    }

    private void Awake()
    {
        _rectTrm = GetComponent<RectTransform>();

        _joinBtn.onClick.AddListener(OpenWindow);
        _closeBtn.onClick.AddListener(CloseWindow);
        _fullscreenSettingBtn.onClick.AddListener(OpenScreenSetting);
        _audioSettingBtn.onClick.AddListener(CloseScreenSetting);
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

    public void OpenScreenSetting()
    {
        Sequence seq = DOTween.Sequence().SetAutoKill(false).SetUpdate(true);
        seq.OnStart(() => _fullscreenGroup.alpha = 1f);
        seq.Append(_fullscreenRectTrm.DOAnchorPosX(15, 0.8f));
        seq.AppendCallback(() =>
        {
            _fullscreenGroup.interactable = true;
            _fullscreenGroup.blocksRaycasts = true;
        });
    }

    public void CloseScreenSetting()
    {
        float screenWidth = Screen.width;
        _fullscreenGroup.interactable = false;
        _fullscreenGroup.blocksRaycasts = false;
        Sequence seq = DOTween.Sequence().SetAutoKill(false).SetUpdate(true);
        seq.Append(_fullscreenRectTrm.DOAnchorPosX(screenWidth, 0.8f));
    }


}
