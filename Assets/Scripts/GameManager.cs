using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ClicksTotalText;
    public TextMeshProUGUI ClicksPerSecondText;
    //public TextMeshProUGUI ClicksPerTapText;

    public static float TotalClicks;
    public static int TotalClicksPerTap;
    public static int TotalMult = 0;

    public void Update()
    {
        // TotalMult = hasUpgrade1 * autoClicksPerSecond1;
        // TotalMult += hasUpgrade2 * autoClicksPerSecond2;
        // TotalMult += hasUpgrade3 * autoClicksPerSecond3;
        // TotalMult += hasUpgrade4 * autoClicksPerSecond4;
        // TotalMult += hasUpgrade5 * autoClicksPerSecond5;
        // TotalMult += hasUpgrade6 * autoClicksPerSecond6;
        // TotalMult += hasUpgrade7 * autoClicksPerSecond7;
        // TotalMult += hasUpgrade8 * autoClicksPerSecond8;
        // TotalMult += hasUpgrade9 * autoClicksPerSecond9;
        // TotalMult += hasUpgrade10 * autoClicksPerSecond10;
        TotalClicks += TotalMult * Time.deltaTime;
        ClicksTotalText.text = "Total Clicks : " + TotalClicks.ToString("0");
        ClicksPerSecondText.text = "Clicks Per Second : " + TotalMult.ToString("0");
    }
}
