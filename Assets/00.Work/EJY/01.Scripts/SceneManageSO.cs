using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SO/SceneManage")]
public class SceneManageSO : ScriptableObject
{
    public void SceneReload() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
