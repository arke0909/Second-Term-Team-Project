using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SO/SceneManage")]
public class SceneManageSO : ScriptableObject
{
    public static string CurrentSceneName => SceneManager.GetActiveScene().name;
    public void SceneLoad(int sceneHash) => SceneManager.LoadScene(sceneHash);
}
