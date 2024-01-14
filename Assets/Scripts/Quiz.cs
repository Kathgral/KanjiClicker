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
    public KanjiData currentKanji;
    public List<(string, string)> currentOptions = new List<(string, string)>();

    void Awake()
    {
        GenerateQuiz();
    }

    void GenerateQuiz()
    {
        currentKanji = GetRandomKanji();
        currentOptions.Clear();
        currentOptions.Add((currentKanji.wk_meanings, currentKanji.fr_meanings));

        // Add three incorrect options
        AddWrongOptions();

        // Update the question text
        Kanji.text = currentKanji.kanji;

        optionsButtons();
    }

    public void optionsButtons()
    {
        // Set the options on the buttons
        for (int i = 0; i < answerButtons.Count; i++)
        {
            TMP_Text buttonText = answerButtons[i].GetComponentInChildren<TMP_Text>();
            switch (DataManager.playerData.Language)
            {
                case "en":
                    buttonText.text = currentOptions[i].Item1;
                    break;
                case "fr":
                    buttonText.text = currentOptions[i].Item2;
                    break;
            }
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(buttonText.text));
        }
    }

    KanjiData GetRandomKanji()
    {
        // Select a random kanji from the unlocked list
        return KanjiManager.kanjiDataList[Random.Range(0, KanjiManager.indexLastKanjiUnlocked+1)];
    }

    void AddWrongOptions()
    {
        string correctMeaning = currentKanji.wk_meanings;
        while (currentOptions.Count < 4)
        {
            KanjiData otherKanji = KanjiManager.kanjiDataList[Random.Range(0, KanjiManager.indexLastKanjiUnlocked+1)];
            (string, string) otherKanjiMeanings = (otherKanji.wk_meanings, otherKanji.fr_meanings);
            if (! currentOptions.Contains(otherKanjiMeanings) ){
                currentOptions.Add(otherKanjiMeanings);
            }
        }

        currentOptions = currentOptions.OrderBy(x => Random.value).ToList();
    }


    public void CheckAnswer(string selectedOption)
    {
        string correctAnswer = "";
        switch (DataManager.playerData.Language)
        {
            case "en":
                correctAnswer = currentKanji.wk_meanings;
                break;
            case "fr":
                correctAnswer = currentKanji.fr_meanings;
                break;
        }
        if (selectedOption == correctAnswer)
        {
            Debug.Log("Correct!");
            switch (DataManager.playerData.Language)
            {
                case "en":
                    answerText.text = "<color=#00ff00ff> Correct!\n </color>" + currentKanji.kanji + ": " + currentKanji.wk_meanings;
                    break;
                case "fr":
                    answerText.text = "<color=#00ff00ff> Correct !\n </color>" + currentKanji.kanji + " : " + currentKanji.fr_meanings;
                    break;
            }
            // Earn points if you have a correct answer
            int rewardPoints = DataManager.playerData.PointsPerClick * 10;
            DataManager.playerData.TotalPoints += rewardPoints;
            DataManager.playerData.TotalNumberOfPointsObtained += rewardPoints;
            DataManager.playerData.GoodAnswersQuiz += 1;
        }
        else
        {
            Debug.Log("Incorrect!");
            switch (DataManager.playerData.Language)
            {
                case "en":
                    answerText.text =  "<color=#ff0000ff> Incorrect!\n </color>" + currentKanji.kanji + ": " + currentKanji.wk_meanings;
                    break;
                case "fr":
                    answerText.text = "<color=#ff0000ff> Incorrect !\n </color>" + currentKanji.kanji + " : " + currentKanji.fr_meanings;
                    break;
            }
        }
        DataManager.playerData.AnswersQuiz += 1;
        GenerateQuiz(); // Generate the next question
    }
}
