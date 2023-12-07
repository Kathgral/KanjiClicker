using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterData
{
    public int strokes;
    public int grade;
    public int freq;
    public int jlpt_old;
    public int jlpt_new;
    public string[] meanings;
    public string[] readings_on;
    public string[] readings_kun;
    public int wk_level;
    public string[] wk_meanings;
    public string[] wk_readings_on;
    public string[] wk_readings_kun;
    public string[] wk_radicals;
}

public class JsonDatabase
{
    public CharacterData ˆê; // The character "ˆê" is used as an example; you can add more characters as needed
}

public class DatabaseManager : MonoBehaviour
{
    public TMP_Text kanjiText;

    void Start()
    {
        // Specify the file path relative to the "Resources" folder
        string filePath = "Assets/Database/kanji.json"; // e.g., "CharacterDatabase"

        // Load the JSON file
        TextAsset jsonFile = Resources.Load<TextAsset>(filePath);

        if (jsonFile != null)
        {
            // Parse JSON data into the JsonDatabase class
            JsonDatabase jsonDatabase = JsonUtility.FromJson<JsonDatabase>(jsonFile.text);

            // Access the data
            Debug.Log("Strokes: " + jsonDatabase.ˆê.strokes);
            Debug.Log("Meanings: " + string.Join(", ", jsonDatabase.ˆê.meanings));

            // Display the kanji character on the UI Text component
            if (kanjiText != null)
            {
                kanjiText.text = jsonDatabase.ˆê.ToString(); // Assuming the kanji character is a string
            }
            else
            {
                Debug.LogWarning("UI Text component not assigned to the script.");
            }

        }
        else
        {
            Debug.LogError("Failed to load JSON file: " + filePath);
        }
    }
}