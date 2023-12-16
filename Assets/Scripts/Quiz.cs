using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class KanjiQuizManager : MonoBehaviour
{
    public TextMeshProUGUI Kanji;
    public TextMeshProUGUI answerText;
    public List<Button> answerButtons; // Assign your 4 answer buttons here
    public List<KanjiData> kanjiDataList;
    public KanjiData currentKanji;
    public List<string> currentOptions = new List<string>();

    void Start()
    {
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
        return KanjiManager.kanjiDataList[Random.Range(0, KanjiManager.indexLastKanjiUnlocked)];

    }

        void AddWrongOptions()
    {
        // Your code might be expecting meanings to be an array, but it's actually a string.
        // If you stored the meanings in the wk_meanings and expect them to be an array, split them here:
        string[] correctMeanings = currentKanji.wk_meanings.Trim('[', ']', '\'').Split(new string[] { "', '" }, System.StringSplitOptions.RemoveEmptyEntries);
        
        // Assuming wk_meanings is a semicolon-separated list of meanings, for example: "['meaning1', 'meaning2']"
        HashSet<string> uniqueMeanings = new HashSet<string>();
        
        // Safely attempt to add meanings to the HashSet
        foreach (var kanji in KanjiManager.kanjiDataList)
        {
            if (!string.IsNullOrWhiteSpace(kanji.wk_meanings))
            {
                string[] meaningsArray = kanji.wk_meanings.Trim('[', ']', '\'').Split(new string[] { "', '" }, System.StringSplitOptions.RemoveEmptyEntries);
                foreach (var meaning in meaningsArray)
                {
                    uniqueMeanings.Add(meaning);
                }
            }
        }

        // Remove the correct answer to ensure it's not duplicated in the wrong options
        foreach (var meaning in correctMeanings)
        {
            uniqueMeanings.Remove(meaning);
        }

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
            answerText.text = "Correct!";
        }
        else
        {
            Debug.Log("Incorrect!");
            answerText.text = "Incorrect!";
        }

        GenerateQuiz(); // Generate the next question
    }
}
