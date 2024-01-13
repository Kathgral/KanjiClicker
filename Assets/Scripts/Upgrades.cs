using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public TextMeshProUGUI PointsPerSecondText;
    public TextMeshProUGUI PointsPerClickText;
    public TextMeshProUGUI UpgradePointsPerClickText;
    public TextMeshProUGUI UpgradePointsPerSecondText;

    private int BaseCostPointsPerClick = 60;
    private int BaseCostPointsPerSecond = 40;
    public static int CostPointsPerClick;
    public static int CostPointsPerSecond;

    public int CalculateUpgradeCost(int Level, int BaseCost, int AdditionalCostFactor = 5)
    {
        int NextLevel = Level + 1;
        int cost = BaseCost * NextLevel + AdditionalCostFactor * ((int)Mathf.Pow(NextLevel, 2) - 1);
        return cost;
    }

    void Awake()
    {
        // Initialize the value with the saved data
        CostPointsPerClick = CalculateUpgradeCost(DataManager.playerData.LevelUpgradePointsPerClick, BaseCostPointsPerClick);
        CostPointsPerSecond = CalculateUpgradeCost(DataManager.playerData.LevelUpgradePointsPerSecond, BaseCostPointsPerSecond);
    }

    public void UpgradePointsPerClick() 
    {
        if (DataManager.playerData.TotalPoints >= CostPointsPerClick)
        { 
            DataManager.playerData.TotalPoints -= CostPointsPerClick;
            DataManager.playerData.PointsPerClick += 1;
            DataManager.playerData.LevelUpgradePointsPerClick += 1;
            CostPointsPerClick = CalculateUpgradeCost(DataManager.playerData.LevelUpgradePointsPerClick, BaseCostPointsPerClick);
            switch (DataManager.playerData.Language)
            {
                case "en":
                    UpgradePointsPerClickText.text = "Increase the number of points per click: \n" + CostPointsPerClick.ToString() + " LP";
                    PointsPerClickText.text = "Learning Points Per Click: " + DataManager.playerData.PointsPerClick;
                    break;
                case "fr":
                    UpgradePointsPerClickText.text = "Augmente le nombre de points par clic :\n" + Upgrades.CostPointsPerClick.ToString() + " PA";
                    PointsPerClickText.text = "Points Par Clic : " + DataManager.playerData.PointsPerClick;
                    break;
            }
        }
    }

    public void UpgradePointsPerSecond() 
    {
        if (DataManager.playerData.TotalPoints >= CostPointsPerSecond)
        { 
            DataManager.playerData.TotalPoints -= CostPointsPerSecond;
            DataManager.playerData.PointsPerSecond += 0.5f;
            DataManager.playerData.LevelUpgradePointsPerSecond += 1;
            CostPointsPerSecond = CalculateUpgradeCost(DataManager.playerData.LevelUpgradePointsPerSecond, BaseCostPointsPerSecond);
            switch (DataManager.playerData.Language)
            {
                case "en":
                    UpgradePointsPerSecondText.text = "Increase the number of points per second: \n" + CostPointsPerSecond + " LP";
                    PointsPerSecondText.text = "Learning Points Per Second: " + DataManager.playerData.PointsPerSecond.ToString("0.0");
                    break;
                case "fr":
                    UpgradePointsPerSecondText.text = "Augmente le nombre de points par seconde :\n" + Upgrades.CostPointsPerSecond.ToString() + " PA";
                    PointsPerSecondText.text = "Points Par Seconde : " + DataManager.playerData.PointsPerSecond.ToString("0.0");
                    break;
            }
        }
    }
}