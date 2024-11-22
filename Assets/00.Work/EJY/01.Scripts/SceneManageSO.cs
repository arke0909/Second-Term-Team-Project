using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SO/SceneManage")]
public class SceneManageSO : ScriptableObject
{
    public static string CurrentSceneName => SceneManager.GetActiveScene().name;
    public void SceneReload(string sceneName) => SceneManager.LoadScene(sceneName);
}
