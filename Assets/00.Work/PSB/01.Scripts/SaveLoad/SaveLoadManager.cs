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
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayerData();
        }
    }

    public void SavePlayerData()
    {
        PlayerData playerData = new PlayerData
        {
            x = player.position.x,
            y = player.position.y
        };

        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, json);
        Debug.Log("Player data saved: " + json);
    }

    public void LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            
            // �÷��̾� ��ġ ������Ʈ
            player.position = new Vector3(playerData.x, playerData.y, player.position.z);
            Debug.Log("Player data loaded: " + json);
        }
        else
        {
            Debug.LogWarning("Player data file not found.");
        }
    }
}
