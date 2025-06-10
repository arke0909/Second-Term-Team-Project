using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class PlayerData
{
    public float x;
    public float y;
}
public class SaveLoadManager : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform�� �����Ϳ��� �����ϰų� �ڵ�� �Ҵ�
    private string filePath;

    private static SaveLoadManager _instnace;
    public static SaveLoadManager Instance => _instnace;

    private void Awake()
    {
        if (_instnace == null)
        {
            _instnace = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ���� ��� ���� (Application.persistentDataPath ���)
        filePath = Path.Combine(Application.persistentDataPath, "playerData.json");

        // �÷��̾� ��ġ �ε�
        LoadPlayerData();
    }

    void Update()
    {
        // 'S' Ű�� ������ �� ��ġ ����
        if (Input.GetKeyDown(KeyCode.B))
        {
            SavePlayerData();
        }
    }

    /// <summary>
    /// Save�ϱ�
    /// </summary>
    public void SavePlayerData()
    {
        Debug.Log("success");
        PlayerData playerData = new PlayerData
        {
            x = player.position.x,
            y = player.position.y
        };
        Debug.Log("success2");
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, json);
        Debug.Log("Player list saved: " + json);
    }

    /// <summary>
    /// Load�ϱ�
    /// </summary>
    public void LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            
            // �÷��̾� ��ġ ������Ʈ
            player.position = new Vector3(playerData.x, playerData.y, player.position.z);
            Debug.Log("Player list loaded: " + json);
        }
        else
        {
            Debug.LogWarning("Player list file not found.");
        }
    }

}
