using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InGameMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject escPanel;
    private bool isOpenMenu;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        escPanel.SetActive(false);
        isOpenMenu = false;
        LoadVolume();
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
        if (isOpenMenu == false)
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
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
        Debug.Log("Setting Complete");
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        Debug.Log("Load Complete");
        SetMusicVolume();
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
        }
    }

}
