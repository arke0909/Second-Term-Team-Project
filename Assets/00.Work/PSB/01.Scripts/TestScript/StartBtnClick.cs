using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtnClick : MonoBehaviour
{
    public void BtnClick()
    {
        SceneManager.LoadScene("TestScenes");
    }
}
