using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI ClicksTotalText;
    public TextMeshProUGUI ClicksPerSecondText;
    public TextMeshProUGUI ClicksPerTapText;

    public float TotalClicks;

    public int TotalClickPerTap;

    public int hasTapUpgrade1;
    public int ClicksPerTap1;
    public int minimumClicksToUnlockTapUpgrade1;
    public void TapUpgrade1()
    {
        if(TotalClicks >= minimumClicksToUnlockTapUpgrade1)
        {
            TotalClicks -= minimumClicksToUnlockTapUpgrade1;
            hasTapUpgrade1 += 1;
            TotalClickPerTap += ClicksPerTap1;  
            ClicksPerTapText.text = "Clicks Per Tap : \n" + TotalClickPerTap.ToString("0");
        }
    }

    public int hasTapUpgrade2;
    public int ClicksPerTap2;
    public int minimumClicksToUnlockTapUpgrade2;
    public void TapUpgrade2()
    {
        if(TotalClicks >= minimumClicksToUnlockTapUpgrade2)
        {
            TotalClicks -= minimumClicksToUnlockTapUpgrade2;
            hasTapUpgrade2 += 1;
            TotalClickPerTap += ClicksPerTap2;  
            ClicksPerTapText.text = "Clicks Per Tap : \n" + TotalClickPerTap.ToString("0");
        }
    }

    public int hasTapUpgrade3;
    public int ClicksPerTap3;
    public int minimumClicksToUnlockTapUpgrade3;
    public void TapUpgrade3()
    {
        if(TotalClicks >= minimumClicksToUnlockTapUpgrade3)
        {
            TotalClicks -= minimumClicksToUnlockTapUpgrade3;
            hasTapUpgrade3 += 1;
            TotalClickPerTap += ClicksPerTap3;  
            ClicksPerTapText.text = "Clicks Per Tap : \n" + TotalClickPerTap.ToString("0");
        }
    }

    
    public void AddClicks()
    {
        TotalClicks += TotalClickPerTap;
        ClicksTotalText.text = "Total Clicks : " + TotalClicks.ToString("0");
    }

    public int hasUpgrade1;
    public int autoClicksPerSecond1;
    public int minimumClicksToUnlockUpgrade1;
    public void AutoClickUpgrade1()
    {
        if(TotalClicks >= minimumClicksToUnlockUpgrade1)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade1;
            hasUpgrade1 += 1;
        }
    }

    public int hasUpgrade2;
    public int autoClicksPerSecond2;
    public int minimumClicksToUnlockUpgrade2;
    public void AutoClickUpgrade2()
    {
        if(TotalClicks >= minimumClicksToUnlockUpgrade2)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade2;
            hasUpgrade2 += 1;
        }
    }

    public int hasUpgrade3;
    public int autoClicksPerSecond3;
    public int minimumClicksToUnlockUpgrade3;
    public void AutoClickUpgrade3()
    {
        if(TotalClicks >= minimumClicksToUnlockUpgrade3)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade3;
            hasUpgrade3 += 1;
        }
    }

    public int hasUpgrade4;
    public int autoClicksPerSecond4;
    public int minimumClicksToUnlockUpgrade4;
    public void AutoClickUpgrade4()
    {
        if(TotalClicks >= minimumClicksToUnlockUpgrade4)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade4;
            hasUpgrade4 += 1;
        }
    }

    public int hasUpgrade5;
    public int autoClicksPerSecond5;
    public int minimumClicksToUnlockUpgrade5;
    public void AutoClickUpgrade5()
    {
        if(TotalClicks >= minimumClicksToUnlockUpgrade5)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade5;
            hasUpgrade5 += 1;
        }
    }

    public int hasUpgrade6;
    public int autoClicksPerSecond6;
    public int minimumClicksToUnlockUpgrade6;
    public void AutoClickUpgrade6()
    {
        if(TotalClicks >= minimumClicksToUnlockUpgrade6)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade6;
            hasUpgrade6 += 1;
        }
    }

    public int hasUpgrade7;
    public int autoClicksPerSecond7;
    public int minimumClicksToUnlockUpgrade7;
    public void AutoClickUpgrade7()
    {
        if(TotalClicks >= minimumClicksToUnlockUpgrade7)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade7;
            hasUpgrade7 += 1;
        }
    }

    public int hasUpgrade8;
    public int autoClicksPerSecond8;
    public int minimumClicksToUnlockUpgrade8;
    public void AutoClickUpgrade8()
    {
        if(TotalClicks >= minimumClicksToUnlockUpgrade8)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade8;
            hasUpgrade8 += 1;
        }
    }

    public int hasUpgrade9;
    public int autoClicksPerSecond9;
    public int minimumClicksToUnlockUpgrade9;
    public void AutoClickUpgrade9()
    {
        if(TotalClicks >= minimumClicksToUnlockUpgrade9)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade9;
            hasUpgrade9 += 1;
        }
    }

    public int hasUpgrade10;
    public int autoClicksPerSecond10;
    public int minimumClicksToUnlockUpgrade10;
    public void AutoClickUpgrade10()
    {
        if(TotalClicks >= minimumClicksToUnlockUpgrade10)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade10;
            hasUpgrade10 += 1;
        }
    }

    public int TotalMult;
    public void Update()
    {
        TotalMult = hasUpgrade1 * autoClicksPerSecond1;
        TotalMult += hasUpgrade2 * autoClicksPerSecond2;
        TotalMult += hasUpgrade3 * autoClicksPerSecond3;
        TotalMult += hasUpgrade4 * autoClicksPerSecond4;
        TotalMult += hasUpgrade5 * autoClicksPerSecond5;
        TotalMult += hasUpgrade6 * autoClicksPerSecond6;
        TotalMult += hasUpgrade7 * autoClicksPerSecond7;
        TotalMult += hasUpgrade8 * autoClicksPerSecond8;
        TotalMult += hasUpgrade9 * autoClicksPerSecond9;
        TotalMult += hasUpgrade10 * autoClicksPerSecond10;
        TotalClicks += TotalMult * Time.deltaTime;
        ClicksTotalText.text = "Total Clicks : " + TotalClicks.ToString("0");
        ClicksPerSecondText.text = "Clicks Per Second : " + TotalMult.ToString("0");
    }
}
