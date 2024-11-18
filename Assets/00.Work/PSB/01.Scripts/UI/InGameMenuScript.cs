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

    private string filePath;

    private void Start()
    {
        Time.timeScale = 1f;
        escPanel.SetActive(false);
        isOpenMenu = false;

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
            Time.timeScale = 0f;
            escPanel.SetActive(true);
            isOpenMenu = true;
        }
        else
        {
            Time.timeScale = 1f;
            escPanel.SetActive(false);
            isOpenMenu = false;
        }
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
