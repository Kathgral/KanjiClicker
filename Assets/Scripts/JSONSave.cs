using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Class to store all data
[System.Serializable]
public class PlayerData
{
    // Don't forget to initialize the value when there is no save
    public float TotalPoints = 0; 
    public float PointsPerClick = 1;
    public float PointsPerSecond = 0;
}


// Class to save/load
public class JSONSave : MonoBehaviour
{
    string saveFilePath;
    public static PlayerData playerData;

    void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log("Save file at: " + saveFilePath);
        LoadGame();
    }

    public void LoadDataToGameManager()
    {
        GameManager.TotalPoints = playerData.TotalPoints;
        GameManager.PointsPerClick = playerData.PointsPerClick;
        GameManager.PointsPerSecond = playerData.PointsPerSecond;
    }

    public void LoadGame()
    {
        playerData = new PlayerData();
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            JsonUtility.FromJsonOverwrite(loadPlayerData, playerData);
            Debug.Log("Load game complete!");
            Debug.Log("Loaded TotalPoints: " + playerData.TotalPoints);
        }
        else
        {
            Debug.Log("There is no save files to load!");
            Debug.Log("New game!");
        }
        LoadDataToGameManager();
    }

    public void UpdateDataFromGameManager()
    {
        playerData.TotalPoints = GameManager.TotalPoints;
        playerData.PointsPerClick = GameManager.PointsPerClick;
        playerData.PointsPerSecond = GameManager.PointsPerSecond;
    }

    public void SaveGame()
    {
        UpdateDataFromGameManager();
        string savePlayerData = JsonUtility.ToJson(playerData);
        File.WriteAllText(saveFilePath, savePlayerData);
        Debug.Log("Save file created at: " + saveFilePath);
    }

    float saveInterval = 1f; // Save every second
    float saveTime = 0; // count the time between saves

    public void Update()
    {
        //save data
        if (saveTime >= saveInterval){
            SaveGame();
            saveTime = 0;
        }
        else{
            saveTime += Time.deltaTime;
        }
    }
}
