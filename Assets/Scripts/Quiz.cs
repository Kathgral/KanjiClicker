using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class KanjiQuizManager : MonoBehaviour
{
    public TextMeshProUGUI Kanji;
    public List<Button> answerButtons; // Assign your 4 answer buttons here
    private List<KanjiData> kanjiDataList;
    private KanjiData currentKanji;
    private List<string> currentOptions = new List<string>();

    void Start()
    {
        // Load the Kanji data from the CSV file
        TextAsset csvFile = Resources.Load<TextAsset>("kanji"); 
        string csvText = csvFile.text;
        kanjiDataList = CSVParser.Parse(csvText);

        GenerateQuiz();
    }

    void GenerateQuiz()
    {
        currentKanji = GetRandomKanji();
        currentOptions.Clear();
        currentOptions.Add(currentKanji.wk_meanings); // Add the correct answer

        // Add three incorrect options
        AddWrongOptions();

        // Update the question text
        Kanji.text = currentKanji.kanji;

        // Set the options on the buttons
        for (int i = 0; i < answerButtons.Count; i++)
        {
            TMP_Text buttonText = answerButtons[i].GetComponentInChildren<TMP_Text>();
            buttonText.text = currentOptions[i];
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(buttonText.text));
        }
    }

    KanjiData GetRandomKanji()
    {
        // Select a random kanji from the unlocked list
        return kanjiDataList[Random.Range(0, KanjiManager.indexLastKanjiUnlocked)];
    }

    void AddWrongOptions()
    {
        HashSet<string> uniqueMeanings = new HashSet<string>(kanjiDataList.SelectMany(k => k.meanings));
        uniqueMeanings.Remove(currentKanji.wk_meanings); // Ensure no duplicate of the correct answer

        while (currentOptions.Count < 4)
        {
            string randomMeaning = uniqueMeanings.ElementAt(Random.Range(0, uniqueMeanings.Count));
            currentOptions.Add(randomMeaning);
            uniqueMeanings.Remove(randomMeaning); // Remove to avoid duplicate wrong answers
        }

        currentOptions = currentOptions.OrderBy(x => Random.value).ToList();
    }

    public void CheckAnswer(string selectedOption)
    {
        if (selectedOption == currentKanji.wk_meanings)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }

        GenerateQuiz(); // Generate the next question
    }
}
