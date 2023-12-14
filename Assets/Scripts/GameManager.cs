using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TotalPointsText;
    public TextMeshProUGUI PointsPerSecondText;
    public TextMeshProUGUI PointsPerClickText;

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

    void Start()
    {
        PointsPerClickText.text = "Learning Points Per Click: " + DataManager.playerData.PointsPerClick;
        PointsPerSecondText.text = "Learning Points Per Second: " + DataManager.playerData.PointsPerSecond.ToString("0.0");
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
            pointsToAdd -= wholePoints;
        }

        // Update UI
        TotalPointsText.text = "Learning Points: " + DataManager.playerData.TotalPoints.ToString("0");
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
