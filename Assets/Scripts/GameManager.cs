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
    public Image ImagePointsPerSecond;
    public Image ImagePointsPerClick;

    // It is best to add every data in the DataManager.playerData class so it can be saved
    public static int TotalMult = 0;  // Represents the total multiplier effect
    // Additional variables for different upgrade types
    public static float AutoClicksPerSecond = 0;
    public static float CostReductionFactor = 1;
    public static float AutoClickSpeedMultiplier = 1;
    public static float BonusClickChance = 0;
    public static float CriticalClickMultiplier = 1;
    public static float PassiveIncomePerSecond = 0;
    public static float LuckFactor = 1;
    public static float PrestigeMultiplier = 1;
    public static float TotalClickMultiplier = 1f;

    // Variables to change the colour of the upgrade button when you have enough points
    private Color32 normalUpgradeColour = new Color32(255,0,0,140);
    private Color32 buyableUpgradeColour = new Color32(255,121,0,190);
    private bool buyableUpgradePointsPerSecond;
    private bool buyableUpgradePointsPerClick;


    void Start()
    {
        PointsPerClickText.text = "Learning Points Per Click: " + DataManager.playerData.PointsPerClick;
        PointsPerSecondText.text = "Learning Points Per Second: " + DataManager.playerData.PointsPerSecond.ToString("0.0");
        int NextLevel = DataManager.playerData.LevelKanji+1;
        KanjiManager.LearningPointsForNextKanji = KanjiManager.BaseCost * NextLevel + KanjiManager.AdditionalCostFactor * ((int)Mathf.Pow(NextLevel, 2) - 1);
    }

    private float pointsToAdd = 0; 
    void Update()
    {
        // Update TotalPoints with passive income and auto clicks
        // TotalPoints += (PassiveIncomePerSecond + AutoClicksPerSecond * AutoClickSpeedMultiplier) * Time.deltaTime;
        
        // Update Total Mult considering all multipliers
        // TotalMult = PointsPerClick * (int)CriticalClickMultiplier * (int)PrestigeMultiplier;
        
        
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
        TotalPointsText.text = "Learning Points: " + DataManager.playerData.TotalPoints.ToString("0");
        if (DataManager.playerData.TotalNumberOfPointsObtained >= KanjiManager.LearningPointsForNextKanji)
        {
            UnlockNewKanji();
        }

        // Change the colour of the upgrade button when you have enough money to buy it      
        bool statePointsForSecondUpgrade = DataManager.playerData.TotalPoints >= Uprgrade2Button.CostPointsPerSecond;
        bool statePointsForClickUpgrade = DataManager.playerData.TotalPoints >= Uprgrade2Button.CostPointsPerClick;

        if (statePointsForSecondUpgrade != buyableUpgradePointsPerSecond)
        {
            ImagePointsPerSecond.color = statePointsForSecondUpgrade ? buyableUpgradeColour : normalUpgradeColour;
            buyableUpgradePointsPerSecond = statePointsForSecondUpgrade;
        }

        if (statePointsForClickUpgrade != buyableUpgradePointsPerClick)
        {
            ImagePointsPerClick.color = statePointsForClickUpgrade ? buyableUpgradeColour : normalUpgradeColour;
            buyableUpgradePointsPerClick = statePointsForClickUpgrade;
        }

        // Check if the sensei button hasn't been called for 3 seconds to delete its message 
        if (Time.time - SenseiButton.lastUpdateTime >= 3f){
            SenseiText.text = "";
        }
    }

    public void UnlockNewKanji()
    {
        KanjiManager.indexLastKanjiUnlocked += 1;
        DataManager.playerData.LevelKanji += 1;
        int NextLevel = DataManager.playerData.LevelKanji+1;
        KanjiManager.LearningPointsForNextKanji = KanjiManager.BaseCost * NextLevel + KanjiManager.AdditionalCostFactor * ((int)Mathf.Pow(NextLevel, 2) - 1);
        StartCoroutine(KanjiMessage());
        KanjiManager.Instance.PrintNumber();
    }

    public TextMeshProUGUI NewUnlockedKanjiText;
    IEnumerator KanjiMessage()
    {
        NewKanjiText.SetActive(true);
        NewUnlockedKanjiText.text = "You unlocked a new kanji: " + KanjiManager.kanjiDataList[KanjiManager.indexLastKanjiUnlocked].kanji;
        yield return new WaitForSeconds(3.0f);
        NewKanjiText.SetActive(false);
    }

//     public void ApplyUpgradeEffect(Upgrade upgrade)
//     {
//         switch (upgrade.Type)
//         {
//             case UpgradeType.Tap:
//                 PointsPerClick += upgrade.CurrentEffect;
//                 // Update UI if necessary
//                 break;

//             case UpgradeType.AutoClick:
//                 AutoClicksPerSecond += upgrade.CurrentEffect;
//                 // Update UI if necessary
//                 break;

//             case UpgradeType.Multiplier:
//                 TotalMult *= upgrade.CurrentEffect;
//                 // Update UI if necessary
//                 break;

//             case UpgradeType.Efficiency:
//                 CostReductionFactor *= upgrade.CurrentEffect;
//                 // Update UI if necessary
//                 break;

//             case UpgradeType.Speed:
//                 AutoClickSpeedMultiplier *= upgrade.CurrentEffect;
//                 // Update UI if necessary
//                 break;

//             case UpgradeType.Bonus:
//                 BonusClickChance += upgrade.CurrentEffect;
//                 // Update UI if necessary
//                 break;

//             case UpgradeType.CriticalClick:
//                 CriticalClickMultiplier *= upgrade.CurrentEffect;
//                 // Update UI if necessary
//                 break;

//             case UpgradeType.PassiveIncome:
//                 PassiveIncomePerSecond += upgrade.CurrentEffect;
//                 // Update UI if necessary
//                 break;

//             case UpgradeType.Luck:
//                 LuckFactor *= upgrade.CurrentEffect;
//                 // Update UI if necessary
//                 break;

//             case UpgradeType.Prestige:
//                 PrestigeMultiplier *= upgrade.CurrentEffect;
//                 // Update UI if necessary
//                 break;
//         }
//     }
}
