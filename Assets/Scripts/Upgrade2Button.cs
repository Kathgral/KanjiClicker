using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Uprgrade2Button : MonoBehaviour
{
    private float NextPointsPerClick = 2;
    private float MultPointsPerClick = 2;
    private float CostPointsPerClick = 100;
    private float MultCostPointsPerClick = 2;
    public TextMeshProUGUI UpgradePointsPerClickText;

    private float NextPointsPerSecond = 1;
    private float MultPointsPerSecond = 2;
    private float CostPointsPerSecond = 50;
    private float MultCostPointsPerSecond = 2;
    public TextMeshProUGUI UpgradePointsPerSecondText;

    void Awake()
    {
        // Initialize the value with the saved data
        while (GameManager.PointsPerClick >= NextPointsPerClick)
        {
            NextPointsPerClick = NextPointsPerClick * MultPointsPerClick;
            CostPointsPerClick = CostPointsPerClick * MultCostPointsPerClick;
        }
        while (GameManager.PointsPerSecond >= NextPointsPerSecond)
        {
            NextPointsPerSecond = NextPointsPerSecond * MultPointsPerSecond;
            CostPointsPerSecond = CostPointsPerSecond * MultCostPointsPerSecond;
        }

        UpgradePointsPerClickText.text = "Increase the number of points per click: \n" + CostPointsPerClick.ToString();
        UpgradePointsPerSecondText.text = "Increase the number of points per second: \n" + CostPointsPerSecond.ToString();
    }

    public void UpgradePointsPerClick() 
    {
        if (GameManager.TotalPoints > CostPointsPerClick)
        { 
            GameManager.TotalPoints -= CostPointsPerClick;
            GameManager.PointsPerClick = NextPointsPerClick;
            NextPointsPerClick = NextPointsPerClick * MultPointsPerClick;
            CostPointsPerClick = CostPointsPerClick * MultCostPointsPerClick;
            UpgradePointsPerClickText.text = "Cost to increase the number of points per click: \n" + CostPointsPerClick.ToString();
        }
    }

    public void UpgradePointsPerSecond() 
    {
        if (GameManager.TotalPoints > CostPointsPerSecond)
        { 
            GameManager.TotalPoints -= CostPointsPerSecond;
            GameManager.PointsPerSecond = NextPointsPerSecond;
            NextPointsPerSecond = NextPointsPerSecond * MultPointsPerSecond;
            CostPointsPerSecond = CostPointsPerSecond * MultCostPointsPerSecond;
            UpgradePointsPerSecondText.text = "Cost to increase the number of points per second: \n" + CostPointsPerSecond.ToString();
        }
    }
}