using DG.Tweening;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class InGameVolumeSetting
{
    public float musicVolume;
    public float sfxVolume;
}

public class InGameMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject escPanel;
    private bool isOpenMenu;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private RectTransform _rectTrm;
    private CanvasGroup _canvasGroup;

    private string filePath;

    private void Start()
    {
        //CloseWindow();

        filePath = Path.Combine(Application.persistentDataPath, "volumeSettings.json");
        LoadVolume();

        // 슬라이더 값 변경 이벤트에 람다식 추가
        musicSlider.onValueChanged.AddListener(value =>
        {
            audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
            SaveVolume();
            Debug.Log("BackGround Music Setting Complete");
        });

        sfxSlider.onValueChanged.AddListener(value =>
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
            SaveVolume();
            Debug.Log("SFX Setting Complete");
        });
    }

    private void Awake()
    {
        _rectTrm = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuOpen();
        }
    }

    public void MenuOpen()
    {
        if (!isOpenMenu)
        {
            OpenWindow();
        }
        else
        {
            CloseWindow();
        }
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
        isOpenMenu = true;
        Time.timeScale = 0f;
    }

    private void CloseWindow()
    {
        float screenHeight = Screen.height;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        Sequence seq = DOTween.Sequence().SetAutoKill(false).SetUpdate(true);
        seq.Append(_rectTrm.DOAnchorPosY(screenHeight, 0.8f));
        //seq.OnComplete(() => _canvasGroup.alpha = 0f);
        isOpenMenu = false;
        Time.timeScale = 1f;
    }

    public void ExitBtn()
    {
#if UNITY_EDITOR
        SceneManager.LoadScene("MenuScene");
#endif
        SceneManager.LoadScene("MenuScene");
    }

    public void SaveVolume()
    {
        InGameVolumeSetting settings = new InGameVolumeSetting
        {
            musicVolume = musicSlider.value,
            sfxVolume = sfxSlider.value
        };

        string json = JsonUtility.ToJson(settings);
        File.WriteAllText(filePath, json);
        Debug.Log("Volume settings saved.");
    }

    public void LoadVolume()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            InGameVolumeSetting settings = JsonUtility.FromJson<InGameVolumeSetting>(json);
            musicSlider.value = settings.musicVolume;
            sfxSlider.value = settings.sfxVolume;

            // 초기값 설정 시 볼륨 적용
            audioMixer.SetFloat("Music", Mathf.Log10(settings.musicVolume) * 20);
            audioMixer.SetFloat("SFX", Mathf.Log10(settings.sfxVolume) * 20);
            Debug.Log("Load Complete");
        }
        else
        {
            Debug.Log("No volume settings found.");
            // 기본값 설정
            musicSlider.value = 1.0f; // 기본값
            sfxSlider.value = 1.0f; // 기본값
            SaveVolume(); // 기본값 저장
        }
    }
}
