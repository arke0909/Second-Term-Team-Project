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
    public Transform player; // 플레이어의 Transform을 에디터에서 설정하거나 코드로 할당
    private string filePath;

    void Start()
    {
        // 파일 경로 설정 (Application.persistentDataPath 사용)
        filePath = Path.Combine(Application.persistentDataPath, "playerData.json");

        // 플레이어 위치 로드
        LoadPlayerData();
    }

    void Update()
    {
        // 'S' 키를 눌렀을 때 위치 저장
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
            
            // 플레이어 위치 업데이트
            player.position = new Vector3(playerData.x, playerData.y, player.position.z);
            Debug.Log("Player data loaded: " + json);
        }
        else
        {
            Debug.LogWarning("Player data file not found.");
        }
    }
}
