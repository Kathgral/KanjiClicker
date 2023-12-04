using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum UpgradeType 
        { 
            Tap,            // Increases the number of clicks per tap
            AutoClick,      // Generates clicks automatically per second
            Multiplier,     // Multiplies the total clicks earned
            Efficiency,     // Reduces the cost of other upgrades
            Speed,          // Increases the speed of auto-clickers
            Bonus,          // Grants occasional bonus clicks or multipliers
            CriticalClick,  // Chance to earn extra clicks on tap
            PassiveIncome,  // Generates passive income over time
            Luck,           // Increases the chance of random positive events
            Prestige        // Improves long-term benefits, possibly reset-related
        };


public class Upgrades : MonoBehaviour
{
    public TextMeshProUGUI ClicksPerTapText;
    
    private float TotalClicks = GameManager.TotalClicks;  // Updated elsewhere
    private int TotalClicksPerTap = GameManager.TotalClicksPerTap;  // Updated elsewhere

    // Initialize your upgrades here
    Upgrade[] upgrades = new Upgrade[10];

   void Start()
    {
        // Tap Upgrade: Increases clicks per tap
        upgrades[0] = new Upgrade { Level = 0, BaseEffect = 1, BaseCost = 50, CostMultiplier = 1.5f, EffectMultiplier = 1.2f, Type = UpgradeType.Tap };

        // AutoClick Upgrade: Generates automatic clicks per second
        upgrades[1] = new Upgrade { Level = 0, BaseEffect = 1, BaseCost = 100, CostMultiplier = 1.6f, EffectMultiplier = 1.3f, Type = UpgradeType.AutoClick };

        // Multiplier Upgrade: Boosts the total clicks earned
        upgrades[2] = new Upgrade { Level = 0, BaseEffect = 2, BaseCost = 200, CostMultiplier = 1.7f, EffectMultiplier = 1.4f, Type = UpgradeType.Multiplier };

        // Efficiency Upgrade: Reduces the cost of other upgrades
        upgrades[3] = new Upgrade { Level = 0, BaseEffect = 5, BaseCost = 150, CostMultiplier = 1.5f, EffectMultiplier = 1.2f, Type = UpgradeType.Efficiency };

        // Speed Upgrade: Increases the speed of auto-clicks
        upgrades[4] = new Upgrade { Level = 0, BaseEffect = 1, BaseCost = 250, CostMultiplier = 1.8f, EffectMultiplier = 1.5f, Type = UpgradeType.Speed };

        // Bonus Upgrade: Grants occasional bonus clicks or multipliers
        upgrades[5] = new Upgrade { Level = 0, BaseEffect = 3, BaseCost = 300, CostMultiplier = 1.9f, EffectMultiplier = 1.6f, Type = UpgradeType.Bonus };

        // Critical Click Upgrade: Chance for extra clicks on tap
        upgrades[6] = new Upgrade { Level = 0, BaseEffect = 4, BaseCost = 350, CostMultiplier = 2.0f, EffectMultiplier = 1.7f, Type = UpgradeType.CriticalClick };

        // Passive Income Upgrade: Generates passive income over time
        upgrades[7] = new Upgrade { Level = 0, BaseEffect = 2, BaseCost = 400, CostMultiplier = 2.1f, EffectMultiplier = 1.8f, Type = UpgradeType.PassiveIncome };

        // Luck Upgrade: Increases the chance of random positive events
        upgrades[8] = new Upgrade { Level = 0, BaseEffect = 5, BaseCost = 500, CostMultiplier = 2.2f, EffectMultiplier = 1.9f, Type = UpgradeType.Luck };

        // Prestige Upgrade: Improves long-term benefits, possibly reset-related
        upgrades[9] = new Upgrade { Level = 0, BaseEffect = 10, BaseCost = 1000, CostMultiplier = 2.5f, EffectMultiplier = 2.0f, Type = UpgradeType.Prestige };
    }


    public void PurchaseUpgrade(int upgradeIndex)
    {
        if (upgradeIndex < 0 || upgradeIndex >= upgrades.Length)
        {
            Debug.LogError("Invalid upgrade index.");
            return;
        }

        Upgrade upgrade = upgrades[upgradeIndex];
        int cost = upgrade.CurrentCost;

        if (TotalClicks >= cost)
        {
            TotalClicks -= cost;
            upgrade.Level++;
            ApplyUpgradeEffect(upgrade);
        }
        else
        {
            Debug.Log("Not enough clicks to purchase this upgrade.");
        }
    }

    private void ApplyUpgradeEffect(Upgrade upgrade)
        {
            switch (upgrade.Type)
            {
                case UpgradeType.Tap:
                    TotalClicksPerTap += upgrade.CurrentEffect;
                    ClicksPerTapText.text = "Clicks Per Tap: \n" + TotalClicksPerTap.ToString("0");
                    break;

                case UpgradeType.AutoClick:
                    // Example: Increase auto clicks per second
                    GameManager.AutoClicksPerSecond += upgrade.CurrentEffect;
                    // Update any relevant UI or game state here
                    break;

                case UpgradeType.Multiplier:
                    GameManager.TotalClickMultiplier *= upgrade.CurrentEffect; // Assuming CurrentEffect is the intended multiplier increase
                    break;

                case UpgradeType.Efficiency:
                    // Example: Reduce the cost of future upgrades
                    GameManager.CostReductionFactor *= upgrade.CurrentEffect;
                    // Update any relevant UI or game state here
                    break;

                case UpgradeType.Speed:
                    // Example: Increase the frequency of auto-clicks
                    GameManager.AutoClickSpeedMultiplier *= upgrade.CurrentEffect;
                    // Update any relevant UI or game state here
                    break;

                case UpgradeType.Bonus:
                    // Example: Increase the chance or effect of bonus clicks
                    GameManager.BonusClickChance += upgrade.CurrentEffect;
                    // Update any relevant UI or game state here
                    break;

                case UpgradeType.CriticalClick:
                    // Example: Increase the chance or multiplier for critical clicks
                    GameManager.CriticalClickMultiplier += upgrade.CurrentEffect;
                    // Update any relevant UI or game state here
                    break;

                case UpgradeType.PassiveIncome:
                    // Example: Generate passive income over time
                    GameManager.PassiveIncomePerSecond += upgrade.CurrentEffect;
                    // Update any relevant UI or game state here
                    break;

                case UpgradeType.Luck:
                    // Example: Increase luck factor for random events
                    GameManager.LuckFactor += upgrade.CurrentEffect;
                    // Update any relevant UI or game state here
                    break;

                case UpgradeType.Prestige:
                    // Example: Enhance long-term benefits, possibly for a reset mechanism
                    GameManager.PrestigeMultiplier += upgrade.CurrentEffect;
                    // Update any relevant UI or game state here
                    break;
            }
        }

}
