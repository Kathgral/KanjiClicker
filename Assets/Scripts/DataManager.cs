using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    string saveFilePath;
    public static PlayerData playerData;

    void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log("Save file at: " + saveFilePath);
        LoadGame();
    }

    public void LoadGame()
    {
        playerData = new PlayerData();
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            JsonUtility.FromJsonOverwrite(loadPlayerData, playerData);
            Debug.Log("Load game complete!");
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
        //Debug.Log("Save file created at: " + saveFilePath);
    }

    float saveInterval = 1f; // Save every x second
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
