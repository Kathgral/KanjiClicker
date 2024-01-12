using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI TotalClicks;
    public TextMeshProUGUI TotalPointsEver;
    public TextMeshProUGUI NextKanji;
    public TextMeshProUGUI AnswersQuiz;

    void Update()
    {
        TotalClicks.text = "Number of clicks:\n" + DataManager.playerData.TotalNumberOfClicks.ToString("0");
        TotalPointsEver.text = "Total learning points:\n" + DataManager.playerData.TotalNumberOfPointsObtained.ToString("0") + " LP";
        AnswersQuiz.text = "Good answers quiz:\n" + DataManager.playerData.GoodAnswersQuiz + " / " + DataManager.playerData.AnswersQuiz;
        if (KanjiManager.indexLastKanjiUnlocked < KanjiManager.LastKanjiUnlockable){
            NextKanji.text = "Next kanji in\n" + (KanjiManager.LearningPointsForNextKanji - DataManager.playerData.TotalNumberOfPointsObtained).ToString("0") + " LP";
        }
        else {NextKanji.text = "You unlocked all the kanji available";}
    }
}
