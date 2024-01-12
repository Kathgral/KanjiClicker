using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class KanjiData
{
    public string kanji;
    public int strokes;
    public int grade;
    public int freq;
    public int jlpt_old;
    public int jlpt_new;
    public string[] meanings;
    public string[] readings_on;
    public string[] readings_kun;
    public int wk_level;
    public string wk_meanings;
    public string wk_readings_on;
    public string wk_readings_kun;
    public string[] wk_radicals;
}


public static class CSVParser
{
    public static List<KanjiData> Parse(string csvText)
    {
        var lines = csvText.Split('\n');
        var header = lines[0].Split(';').Select(s => s.Trim()).ToArray();

        var data = new List<KanjiData>();

        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(';');

            var kanjiData = new KanjiData();

            for (int j = 0; j < header.Length && j < values.Length; j++)
            {
                switch (header[j])
                {
                    case "kanji":
                        kanjiData.kanji = values[j];
                        break;
                    case "wk_meanings":
                        kanjiData.wk_meanings = values[j].Replace("[", "").Replace("]", "");
                        break;
                    case "wk_readings_on":
                        kanjiData.wk_readings_on = values[j].Replace("[", "").Replace("]", "");
                        break;
                    case "wk_readings_kun":
                        kanjiData.wk_readings_kun = values[j].Replace("[", "").Replace("]", "");
                        break;
                }
            }

            data.Add(kanjiData);
        }

        return data;
    }
}

public class KanjiManager : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public GameObject objectKanjiDisplay;
    public TextMeshProUGUI kanjiNumberText;
    public static int indexLastKanjiUnlocked;
    public static int LearningPointsForNextKanji;
    public static int indexKanji=0;
    public static int BaseCost;
    public static int AdditionalCostFactor;
    public static List<KanjiData> kanjiDataList; // All kanji of the csv
    public static KanjiManager Instance;

    public static int LastKanjiUnlockable = 2500; // lock the number of kanji unlockable (index so n+1 kanji)

    public Slider kanjiSlider_;
    public static Slider kanjiSlider;

    void Awake()
    {
        BaseCost = 100;
        AdditionalCostFactor = 5;
        Instance = this;
    }

    void Start()
    {
        objectKanjiDisplay.SetActive(false); // Deactivate the kanji display
        indexLastKanjiUnlocked = 3 + DataManager.playerData.LevelKanji; // Start with 3+1=4 kanji
        TextAsset csvFile = Resources.Load<TextAsset>("kanji"); 
        string csvText = csvFile.text;
        kanjiDataList = CSVParser.Parse(csvText);
        PrintKanji(kanjiDataList[indexKanji]);
        PrintNumber();
        kanjiSlider = kanjiSlider_;
        kanjiSlider.onValueChanged.AddListener(OnSliderValueChanged);
        UpdateSliderValue();
    }


    void PrintKanji(KanjiData kanjiData)
    {
        displayText.text = $"<b>Kanji:</b> \n{kanjiData.kanji}\n\n" +
            $"<b>Meanings:</b> \n{kanjiData.wk_meanings}";
        if (kanjiData.wk_readings_on != "") {
            displayText.text += $"\n\n<b>On readings:</b> \n{kanjiData.wk_readings_on}";
        }
        if (kanjiData.wk_readings_kun != "") {
            displayText.text += $"\n\n<b>Kun readings:</b> \n{kanjiData.wk_readings_kun}";
        }
    }


    public void PrintNumber()
    {
        kanjiNumberText.text = "" + (indexKanji+1) + " / " + (indexLastKanjiUnlocked+1);
    }



    public void OpenKanjiDisplayOnClick()
    {
        objectKanjiDisplay.SetActive(true);
    }

    public void CloseKanjiDisplayOnClick()
    {
        objectKanjiDisplay.SetActive(false);
    }

    public void PreviousKanjiOnClick()
    {
        indexKanji = indexKanji - 1;
        if (indexKanji<0) {indexKanji = indexLastKanjiUnlocked;}
        PrintKanji(kanjiDataList[indexKanji]);
        PrintNumber();
        kanjiSlider.value = indexKanji;
    }
    
    public void NextKanjiOnClick()
    {
        indexKanji = indexKanji + 1;
        if (indexKanji > indexLastKanjiUnlocked){indexKanji = 0;}
        PrintKanji(kanjiDataList[indexKanji]);
        PrintNumber();
        kanjiSlider.value = indexKanji;
    }

    // slider to change kanji
    void OnSliderValueChanged(float value)
    {
        indexKanji =  Mathf.RoundToInt(value);
        PrintKanji(kanjiDataList[indexKanji]);
        PrintNumber();
    }

    private void UpdateSliderValue()
    {
        kanjiSlider.maxValue = indexLastKanjiUnlocked;
        kanjiSlider.value = indexKanji;
    }
}


