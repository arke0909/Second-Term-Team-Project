using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject escPanel;
    private bool isOpenMenu;

    private void Start()
    {
        escPanel.SetActive(false);
        isOpenMenu = false;
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


}
