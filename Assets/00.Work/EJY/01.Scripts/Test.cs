using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public string n;
    private void Update()
    {
        if(Keyboard.current.qKey.wasPressedThisFrame)
            SceneManager.LoadScene(n);
    }
}
