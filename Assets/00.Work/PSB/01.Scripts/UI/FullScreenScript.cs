using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenScript : MonoBehaviour
{
    private FullScreenMode screenMode;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private TMP_Text resolutionText; // TextMeshPro UI 요소
    [SerializeField] private Toggle toggle;
    private List<Resolution> resolutions = new List<Resolution>();
    private int currentResolutionIndex = 0;

    [System.Obsolete]
    private void Start()
    {
        InitUI();
        UpdateResolutionText();

        leftButton.onClick.AddListener(SelectPreviousResolution);
        rightButton.onClick.AddListener(SelectNextResolution);

        toggle.onValueChanged.AddListener(FullScreen);
    }

    public void FullScreen(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        toggle.onValueChanged.AddListener(FullScreen);
    }

    private void InitUI()
    {
        resolutions.Clear(); // 리스트 초기화

        // HD, QHD, FullHD 해상도를 필터링
        foreach (Resolution resolution in Screen.resolutions)
        {
            if ((resolution.width == 1280 && resolution.height == 720) || // HD
                (resolution.width == 1920 && resolution.height == 1080) || // Full HD
                (resolution.width == 2560 && resolution.height == 1440))   // QHD
            {
                resolutions.Add(resolution);
            }
        }

        // 현재 해상도 인덱스 초기화
        currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i; // 현재 화면 해상도와 일치하는 인덱스 찾기
                break;
            }
        }

        toggle.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    [System.Obsolete]
    private void SelectPreviousResolution()
    {
        currentResolutionIndex--;
        if (currentResolutionIndex < 0)
        {
            currentResolutionIndex = resolutions.Count - 1; // 마지막 해상도로 순환
        }
        UpdateResolutionText();
    }

    [System.Obsolete]
    private void SelectNextResolution()
    {
        currentResolutionIndex++;
        if (currentResolutionIndex >= resolutions.Count)
        {
            currentResolutionIndex = 0; // 첫 번째 해상도로 순환
        }
        UpdateResolutionText();
    }

    [System.Obsolete]
    private void UpdateResolutionText()
    {
        Resolution currentResolution = resolutions[currentResolutionIndex];
        resolutionText.text = $"{currentResolution.width}x{currentResolution.height} {currentResolution.refreshRate}Hz";
    }

    public void OkBtnClick()
    {
        Screen.SetResolution(resolutions[currentResolutionIndex].width, resolutions[currentResolutionIndex].height, screenMode);
    }
}
