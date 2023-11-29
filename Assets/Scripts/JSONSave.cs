using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class JSONSave : MonoBehaviour
{
    Manager manager;
    string saveFilePath;

    public static JSONSave instance;
    void Awake() {
        instance = this;
    }


    void Start()
    {
        // manager = new Manager();
        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
        LoadGame();
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            manager = JsonUtility.FromJson<Manager>(loadPlayerData);

            Debug.Log("Load game complete!");
        }
        else{
            Debug.Log("There is no save files to load!");
            NewGame();
        }
    }

    public void NewGame()
    {
        manager.TotalClicks = 10;
        manager.TotalClickPerTap = 1;

        Debug.Log("New game!");
    }

    public void SaveGame()
    {
        string savePlayerData = JsonUtility.ToJson(manager);
        File.WriteAllText(saveFilePath, savePlayerData);

        Debug.Log("Save file created at: " + saveFilePath);
    }


    public void DeleteSaveFile()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);

            Debug.Log("Save file deleted!");
        }
        else
            Debug.Log("There is nothing to delete!");
    }
}
