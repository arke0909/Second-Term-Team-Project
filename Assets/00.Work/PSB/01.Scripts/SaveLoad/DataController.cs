using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class DataController
{
    private static string SavePath => Application.persistentDataPath + "/saves/";

    public static void Save(GameData gameData, string saveFileName)
    {
        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
        }
        string saveJson = JsonUtility.ToJson(gameData);

        string saveFilePath = SavePath + saveFileName + ".json";

        File.WriteAllText(saveFilePath, saveJson);
        Debug.Log("Save Succes : " + saveFilePath);
    }

    public static GameData Load(string saveFileName)
    {
        string saveFilePath = SavePath + saveFileName + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.LogError("NOOOOO");
            return null;
        }
        string saveFile = File.ReadAllText(saveFilePath);
        GameData gameData = JsonUtility.FromJson<GameData>(saveFile);
        return gameData;
    }

}
