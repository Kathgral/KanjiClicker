using System;
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
    public CharacterData Žµ; // The character "Žµ" is used as an example; you can add more characters as needed
}

public class DatabaseManager : MonoBehaviour
{
    public TMP_Text kanjiText;

    void Start()
    {
        string filePath = "kanji";

        // Load the JSON file
        TextAsset jsonFile = Resources.Load<TextAsset>(filePath);

        if (jsonFile != null)
        {
            // Parse JSON data into a dictionary where the keys are strings (kanji characters)
            // and the values are CharacterData objects
            Dictionary<string, CharacterData> jsonDatabase = DeserializeJsonDatabase(jsonFile.text);

            // Check if the key "Žµ" exists in the dictionary
            if (jsonDatabase.ContainsKey("Žµ"))
            {
                // Access the data for "Žµ"
                CharacterData characterData = jsonDatabase["Žµ"];

                // Access the meanings array
                string[] meanings = characterData.meanings;

                // Display the first meaning on the UI Text component
                if (meanings != null && meanings.Length > 0)
                {
                    if (kanjiText != null)
                    {
                        kanjiText.text = meanings[0];
                    }
                    else
                    {
                        Debug.LogWarning("UI Text component not assigned to the script.");
                    }
                }
                else
                {
                    Debug.LogWarning("Meanings array is null or empty for character 'Žµ'.");
                }
            }
            else
            {
                Debug.LogError("Key 'Žµ' not found in the JSON database.");
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON file: " + filePath);
        }
    }

    private Dictionary<string, CharacterData> DeserializeJsonDatabase(string jsonText)
    {
        Dictionary<string, CharacterData> result = new Dictionary<string, CharacterData>();

        try
        {
            // Parse JSON data directly into a dictionary
            var jsonDict = JsonUtility.FromJson<Dictionary<string, CharacterData>>(jsonText);

            // Copy the entries from the parsed dictionary to the result dictionary
            foreach (var entry in jsonDict)
            {
                result[entry.Key] = entry.Value;
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error deserializing JSON: " + e.Message);
        }

        return result;
    }
}
