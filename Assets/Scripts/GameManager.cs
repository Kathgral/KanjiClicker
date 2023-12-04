using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ClicksTotalText;
    public TextMeshProUGUI ClicksPerSecondText;

    public static float TotalClicks;
    public static int TotalClicksPerTap = 1;  // Initial value set to 1 for base tap effect
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

    void Update()
    {
        // Update TotalClicks with passive income and auto clicks
        TotalClicks += (PassiveIncomePerSecond + AutoClicksPerSecond * AutoClickSpeedMultiplier) * Time.deltaTime;
        
        // Update Total Mult considering all multipliers
        TotalMult = TotalClicksPerTap * (int)CriticalClickMultiplier * (int)PrestigeMultiplier;

        // Update UI
        ClicksTotalText.text = "Learning Points: " + TotalClicks.ToString("0");
        ClicksPerSecondText.text = "Learning Points Per Second: " + TotalMult.ToString("0");
    }

    public void ApplyUpgradeEffect(Upgrade upgrade)
    {
        switch (upgrade.Type)
        {
            case UpgradeType.Tap:
                TotalClicksPerTap += upgrade.CurrentEffect;
                // Update UI if necessary
                break;

            case UpgradeType.AutoClick:
                AutoClicksPerSecond += upgrade.CurrentEffect;
                // Update UI if necessary
                break;

            case UpgradeType.Multiplier:
                TotalMult *= upgrade.CurrentEffect;
                // Update UI if necessary
                break;

            case UpgradeType.Efficiency:
                CostReductionFactor *= upgrade.CurrentEffect;
                // Update UI if necessary
                break;

            case UpgradeType.Speed:
                AutoClickSpeedMultiplier *= upgrade.CurrentEffect;
                // Update UI if necessary
                break;

            case UpgradeType.Bonus:
                BonusClickChance += upgrade.CurrentEffect;
                // Update UI if necessary
                break;

            case UpgradeType.CriticalClick:
                CriticalClickMultiplier *= upgrade.CurrentEffect;
                // Update UI if necessary
                break;

            case UpgradeType.PassiveIncome:
                PassiveIncomePerSecond += upgrade.CurrentEffect;
                // Update UI if necessary
                break;

            case UpgradeType.Luck:
                LuckFactor *= upgrade.CurrentEffect;
                // Update UI if necessary
                break;

            case UpgradeType.Prestige:
                PrestigeMultiplier *= upgrade.CurrentEffect;
                // Update UI if necessary
                break;
        }
    }
}
