using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Class to store all data
[System.Serializable]
public class PlayerData
{
    // Don't forget to initialize the value when there is no save
    public float TotalClicks = 0; 
    public int TotalClicksPerTap = 1;
}


// Class to save/load
public class JSONSave : MonoBehaviour
{
    string saveFilePath;
    public static PlayerData playerData;

    void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
        LoadGame();
    }

    public void LoadDataToGameManager()
    {
        GameManager.TotalClicks = playerData.TotalClicks;
        GameManager.TotalClicksPerTap = playerData.TotalClicksPerTap;
    }

    public void LoadGame()
    {
        playerData = new PlayerData();
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            JsonUtility.FromJsonOverwrite(loadPlayerData, playerData);
            Debug.Log("Load game complete!");
            Debug.Log("Loaded TotalClicks: " + playerData.TotalClicks);
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
        playerData.TotalClicks = GameManager.TotalClicks;
        playerData.TotalClicksPerTap = GameManager.TotalClicksPerTap;        
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
