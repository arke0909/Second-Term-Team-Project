using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class UIVolumeSetting
{
    public float musicVolume;
    public float sfxVolume;
}

public class MenuSceneBtnClick : MonoBehaviour
{
    /*[SerializeField] private GameObject panel;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        LoadVolume();
    }

    public void StartBtnClick()
    {
        SceneManager.LoadScene("Map");
        DOTween.KillAll();
    }

    public void ExitBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
        Debug.Log("BackGround Music Setting Complete");
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        Debug.Log("SFX Setting Complete");
    }

    public void LoadVolume()
    {
        try
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            Debug.Log("Load Complete");
            SetMusicVolume();
            SetSFXVolume();
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    public void CheckVolume()
    {
        if (PlayerPrefs.HasKey("musicVolmue"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }*/


    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private string filePath;

    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "volumeSettings.json");
        LoadVolume();

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

    public void StartBtnClick()
    {
        SceneManager.LoadScene("Map");
    }

    public void ExitBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void SaveVolume()
    {
        UIVolumeSetting settings = new UIVolumeSetting
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
            UIVolumeSetting settings = JsonUtility.FromJson<UIVolumeSetting>(json);
            musicSlider.value = settings.musicVolume;
            sfxSlider.value = settings.sfxVolume;

            audioMixer.SetFloat("Music", Mathf.Log10(settings.musicVolume) * 20);
            audioMixer.SetFloat("SFX", Mathf.Log10(settings.sfxVolume) * 20);
            Debug.Log("Load Complete");
        }
        else
        {
            Debug.Log("No volume settings found.");
            musicSlider.value = 1.0f; 
            sfxSlider.value = 1.0f;
            SaveVolume();
        }
    }

}
