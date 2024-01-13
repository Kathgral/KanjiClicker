using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class StartingScreenManager : MonoBehaviour
{
    string saveFilePath;
    public static PlayerData playerData;
    public TextMeshProUGUI TouchScreen;
    public TextMeshProUGUI Developers;
    public AudioSource audioSource;
    
    void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log("Save file at: " + saveFilePath);
        LoadGame();
    }

    void Start()
    {
        Translate();
        Volume();
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

    private void Translate()
    {
        switch (playerData.Language)
        {
            case "en":
                TouchScreen.text = "Touch The Screen To Continue";
                Developers.text = "By\n" +
                    "Jules FÉRON\n" +
                    "Félix DOUBLET\n" +
                    "Quentin BANET";
                break;
            case "fr":
                TouchScreen.text = "Touchez l'écran pour continuer";
                Developers.text = "Par\n" +
                    "Jules FÉRON\n" +
                    "Félix DOUBLET\n" +
                    "Quentin BANET";
                break;
        }
    }

    void Volume()
    {
        float volume = playerData.Volume;
        float normalizedVolume = volume / 5.0f;
        audioSource.volume = normalizedVolume;
    }
}
