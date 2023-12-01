using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ClicksTotalText;
    public TextMeshProUGUI ClicksPerSecondText;
    //public TextMeshProUGUI ClicksPerTapText;

    public static float TotalClicks;
    public static int TotalClicksPerTap;

    void Start() {
        JSONSave.instance.LoadGame();
        TotalClicks = JSONSave.playerData.TotalClicks;
        TotalClicksPerTap = JSONSave.playerData.TotalClicksPerTap;
    }

    public static int TotalMult = 0;
    float saveInterval = 1f; // Save every second
    float saveTime = 0; // time for the save

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


        //save data
        if (saveTime >= saveInterval)
        {
            JSONSave.playerData.TotalClicks = TotalClicks;
            JSONSave.playerData.TotalClicksPerTap = TotalClicksPerTap;
            JSONSave.instance.SaveGame();
            saveTime = 0;
        }
        else
        {
            saveTime += Time.deltaTime;
        }

    }
}
