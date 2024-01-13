using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TotalPointsText;
    public TextMeshProUGUI PointsPerSecondText;
    public TextMeshProUGUI PointsPerClickText;
    public TextMeshProUGUI SenseiText;  
    public GameObject NewKanjiText;
    public GameObject ProtectiveScreen;
    public Image ImagePointsPerSecond;
    public Image ImagePointsPerClick;

    // Variables to change the color of the upgrade button when you have enough points
    private bool buyableUpgradePointsPerSecond;
    private bool buyableUpgradePointsPerClick;

    // Variables to avoid that the click from the starting screen goes to the game screen
    bool boolProtectiveScreen = false;
    float activationTimer = 0.1f;

    void Awake()
    {
        ProtectiveScreen.SetActive(true);
    }
    void Start()
    {
        // PointsPerClickText.text = "Learning Points Per Click: " + DataManager.playerData.PointsPerClick;
        // PointsPerSecondText.text = "Learning Points Per Second: " + DataManager.playerData.PointsPerSecond.ToString("0.0");
        int NextLevel = DataManager.playerData.LevelKanji+1;
        KanjiManager.LearningPointsForNextKanji = CostNextKanji(NextLevel, KanjiManager.BaseCost);
        //KanjiManager.BaseCost * NextLevel + KanjiManager.AdditionalCostFactor * ((int)Mathf.Pow(NextLevel, 2) - 1);
    }

    int CostNextKanji(int level, int BaseCost, int AdditionalCostFactor = 5)
    {
        int cost = 0;
        for (int i = 1; i <= level; i++)
        {
            cost += BaseCost * i + AdditionalCostFactor * ((int)Mathf.Pow(i, 2) - 1);
        }
        return cost;
    }

    private float pointsToAdd = 0; 
    void Update()
    {
        // To avoid that the click from the starting screen goes to the game screen
        if (!boolProtectiveScreen)
        {
            activationTimer -= Time.deltaTime;

            if (activationTimer <= 0.0f)
            {
                boolProtectiveScreen = true;
                ProtectiveScreen.SetActive(false);
            }
        }
       
        // the line below does not work with huge number because of approximation
        // DataManager.playerData.TotalPoints += DataManager.playerData.PointsPerSecond * Time.deltaTime; 
        // Update TotalPoints with passive points per second
        pointsToAdd += DataManager.playerData.PointsPerSecond * Time.deltaTime;
        if (pointsToAdd >= 1)
        {
            int wholePoints = Mathf.FloorToInt(pointsToAdd);
            DataManager.playerData.TotalPoints += wholePoints;
            DataManager.playerData.TotalNumberOfPointsObtained += wholePoints;
            pointsToAdd -= wholePoints;
        }

        // Update UI
        TotalPointsText.text = DataManager.playerData.TotalPoints.ToString("0");
        if (DataManager.playerData.TotalNumberOfPointsObtained >= KanjiManager.LearningPointsForNextKanji && KanjiManager.indexLastKanjiUnlocked < KanjiManager.LastKanjiUnlockable)
        {
            UnlockNewKanji();
            BackgroundManager.Instance.ShowNextMonth();
        }

        // Change the color of the upgrade button when you have enough money to buy it      
        bool statePointsForSecondUpgrade = DataManager.playerData.TotalPoints >= Upgrades.CostPointsPerSecond;
        bool statePointsForClickUpgrade = DataManager.playerData.TotalPoints >= Upgrades.CostPointsPerClick;

        if (statePointsForSecondUpgrade != buyableUpgradePointsPerSecond)
        {
            ImagePointsPerSecond.color = statePointsForSecondUpgrade ? BackgroundManager.buyableUpgradeColor : BackgroundManager.normalUpgradeColor;
            buyableUpgradePointsPerSecond = statePointsForSecondUpgrade;
        }

        if (statePointsForClickUpgrade != buyableUpgradePointsPerClick)
        {
            ImagePointsPerClick.color = statePointsForClickUpgrade ? BackgroundManager.buyableUpgradeColor : BackgroundManager.normalUpgradeColor;
            buyableUpgradePointsPerClick = statePointsForClickUpgrade;
        }

        // Check if the sensei button hasn't been called for 3 seconds to delete its message 
        if (Time.time - SenseiButton.lastUpdateTime >= 3f){
            SenseiText.text = "";
        }
    }

    public void UnlockNewKanji()
    {
        if (KanjiManager.indexLastKanjiUnlocked < KanjiManager.LastKanjiUnlockable)
        {
            KanjiManager.indexLastKanjiUnlocked += 1;
            DataManager.playerData.LevelKanji += 1;
            int NextLevel = DataManager.playerData.LevelKanji+1;
            KanjiManager.LearningPointsForNextKanji = CostNextKanji(NextLevel, KanjiManager.BaseCost);
            StartCoroutine(KanjiMessage());
            KanjiManager.Instance.PrintNumber();
            KanjiManager.kanjiSlider.maxValue = KanjiManager.indexLastKanjiUnlocked;
        }
    }

    public TextMeshProUGUI NewUnlockedKanjiText;
    IEnumerator KanjiMessage()
    {
        NewKanjiText.SetActive(true);
        switch (DataManager.playerData.Language)
            {
                case "en":
                    NewUnlockedKanjiText.text = "You unlocked a new kanji: " + KanjiManager.kanjiDataList[KanjiManager.indexLastKanjiUnlocked].kanji;
                    break;
                case "fr":
                    NewUnlockedKanjiText.text = "Tu as débloqué un nouveau kanji : " + KanjiManager.kanjiDataList[KanjiManager.indexLastKanjiUnlocked].kanji;
                    break;
            }
        yield return new WaitForSeconds(3.0f);
        NewKanjiText.SetActive(false);
    }

}
