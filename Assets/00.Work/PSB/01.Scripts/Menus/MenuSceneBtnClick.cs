using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneBtnClick : MonoBehaviour
{
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

}
