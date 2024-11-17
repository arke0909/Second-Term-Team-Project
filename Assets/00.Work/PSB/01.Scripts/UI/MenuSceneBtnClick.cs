using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneBtnClick : MonoBehaviour
{
    [SerializeField] private GameObject panel;
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

    public void SettingBtn()
    {
        DOTween.Init();
        panel.transform.DOMoveY(transform.position.y + 500, 1).OnComplete(() => { Debug.Log(1); });
    }

    public void SettingExitBtn()
    {
        DOTween.Init();
        panel.transform.DOMoveY(transform.position.y - 500, 1);
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
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        Debug.Log("Load Complete");
        SetMusicVolume();
        SetSFXVolume();
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
    }


}
