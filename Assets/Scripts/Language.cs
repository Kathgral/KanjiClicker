using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    // Settings menu
    public TextMeshProUGUI Stats;
    public TextMeshProUGUI TotalClicks;
    public TextMeshProUGUI TotalPointsEver;
    public TextMeshProUGUI NextKanji;
    public TextMeshProUGUI AnswersQuiz;
    public TextMeshProUGUI Settings;
    public TextMeshProUGUI NextSong;
    public TextMeshProUGUI NextMonth;
    // Score overlay
    public TextMeshProUGUI PointsText;
    public TextMeshProUGUI PointsPerSecond;
    public TextMeshProUGUI PointsPerClick;
    // Upgrades
    public TextMeshProUGUI UpgradePointsPerClick;
    public TextMeshProUGUI UpgradePointsPerSecond;
    // Quiz
    public TextMeshProUGUI Question;
    // Month
    public TextMeshProUGUI Month;
    private List<string> monthList = new List<string>
    {
        "March", "April", "May", "June", "July", "August", "September",
        "October", "November", "December", "January", "February"
    };
    private List<string> monthListFR = new List<string>
    {
        "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre",
        "Octobre", "Novembre", "Décembre", "Janvier", "Février"
    };


    void Start()
    {
        Translate();
    }

    public void TranslateButton()
    {
        switch (DataManager.playerData.Language)
        {
            case "en":
                DataManager.playerData.Language = "fr";
                break;
            case "fr":
                DataManager.playerData.Language = "en";
                break;
        }
        Translate();
    }

    private void Translate()
    {
        switch (DataManager.playerData.Language)
        {
            case "en":
                // settings menu
                Stats.text = "Statistics:";
                TotalClicks.text = "Number of clicks:\n" + DataManager.playerData.TotalNumberOfClicks.ToString("0");
                TotalPointsEver.text = "Total learning points:\n" + DataManager.playerData.TotalNumberOfPointsObtained.ToString("0") + " LP";
                AnswersQuiz.text = "Good answers quiz:\n" + DataManager.playerData.GoodAnswersQuiz + " / " + DataManager.playerData.AnswersQuiz;
                if (KanjiManager.indexLastKanjiUnlocked < KanjiManager.LastKanjiUnlockable){
                    NextKanji.text = "Next kanji in\n" + (KanjiManager.LearningPointsForNextKanji - DataManager.playerData.TotalNumberOfPointsObtained).ToString("0") + " LP";
                }
                else {NextKanji.text = "You unlocked all the kanji available";}
                Settings.text = "Settings:";
                NextSong.text = "Next Song";
                NextMonth.text = "Next Month";
                // Score overlay
                PointsText.text = "Learning Points:";
                PointsPerClick.text = "Learning Points Per Click: " + DataManager.playerData.PointsPerClick;
                PointsPerSecond.text = "Learning Points Per Second:" + DataManager.playerData.PointsPerSecond.ToString("0.0");
                // Upgrades
                UpgradePointsPerClick.text = "Increase the number of points per click: \n" + Upgrades.CostPointsPerClick.ToString() + " LP";
                UpgradePointsPerSecond.text = "Increase the number of points per second: \n" + Upgrades.CostPointsPerSecond.ToString() + " LP";
                // Month
                Month.text = monthList[DataManager.playerData.indexBackgroundImage];
                // Quiz
                Question.text = "What is the signification of:";
                break;

            case "fr":
                // settings menu
                Stats.text = "Statistiques :";
                TotalClicks.text = "Nombre de clics\n" + DataManager.playerData.TotalNumberOfClicks.ToString("0");
                TotalPointsEver.text = "Points d'apprentissage\n" + DataManager.playerData.TotalNumberOfPointsObtained.ToString("0") + " PA";
                AnswersQuiz.text = "Bonnes réponses quiz\n" + DataManager.playerData.GoodAnswersQuiz + " / " + DataManager.playerData.AnswersQuiz;
                if (KanjiManager.indexLastKanjiUnlocked < KanjiManager.LastKanjiUnlockable){
                    NextKanji.text = "Prochain kanji dans\n" + (KanjiManager.LearningPointsForNextKanji - DataManager.playerData.TotalNumberOfPointsObtained).ToString("0") + " PA";
                }
                else {NextKanji.text = "Tous les kanjis disponibles sont débloqués";}
                Settings.text = "Paramètres :";
                NextSong.text = "Chanson suivante";
                NextMonth.text = "Mois prochain";
                // Score overlay
                PointsText.text = "Points d'Apprentissage";
                PointsPerClick.text = "Points Par Clic : " + DataManager.playerData.PointsPerClick;
                PointsPerSecond.text = "Points Par Seconde : " + DataManager.playerData.PointsPerSecond.ToString("0.0");
                // Upgrades
                UpgradePointsPerClick.text = "Augmente le nombre de points par clic :\n" + Upgrades.CostPointsPerClick.ToString() + " PA";
                UpgradePointsPerSecond.text = "Augmente le nombre de points par seconde :\n" + Upgrades.CostPointsPerSecond.ToString() + " PA";
                // Month
                Month.text = monthListFR[DataManager.playerData.indexBackgroundImage];
                // Quiz
                Question.text = "Quelle est la signification de :";
                break;
        }
    }
}
