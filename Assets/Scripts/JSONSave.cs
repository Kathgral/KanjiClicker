using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// All the data to save/load
[System.Serializable]
public class PlayerData
{
    // Don't forget to initialize the value when there is no save
    public float TotalClicks = 0; 
    public int TotalClicksPerTap = 1;
}


// Functions to save and load
public class JSONSave : MonoBehaviour
{
    //public PlayerData playerData;  // Reference to the player data

    string saveFilePath;
    public static PlayerData playerData;

    public static JSONSave instance;
    void Awake()
    {
        instance = this;
        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
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
    }

    public void SaveGame()
    {
        string savePlayerData = JsonUtility.ToJson(playerData);
        File.WriteAllText(saveFilePath, savePlayerData);
        Debug.Log("Save file created at: " + saveFilePath);
    }

}
