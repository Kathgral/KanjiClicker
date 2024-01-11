using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Uprgrade2Button : MonoBehaviour
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

        UpgradePointsPerClickText.text = "Increase the number of points per click: \n" + CostPointsPerClick.ToString();
        UpgradePointsPerSecondText.text = "Increase the number of points per second: \n" + CostPointsPerSecond.ToString();
    }

    public void UpgradePointsPerClick() 
    {
        if (DataManager.playerData.TotalPoints >= CostPointsPerClick)
        { 
            DataManager.playerData.TotalPoints -= CostPointsPerClick;
            DataManager.playerData.PointsPerClick += 1;
            DataManager.playerData.LevelUpgradePointsPerClick += 1;
            CostPointsPerClick = CalculateUpgradeCost(DataManager.playerData.LevelUpgradePointsPerClick, BaseCostPointsPerClick);
            UpgradePointsPerClickText.text = "Increase the number of points per click: \n" + CostPointsPerClick.ToString();
            PointsPerClickText.text = "Learning Points Per Click: " + DataManager.playerData.PointsPerClick;
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
            UpgradePointsPerSecondText.text = "Increase the number of points per second: \n" + CostPointsPerSecond;
            PointsPerSecondText.text = "Learning Points Per Second: " + DataManager.playerData.PointsPerSecond.ToString("0.0");
        }
    }
}