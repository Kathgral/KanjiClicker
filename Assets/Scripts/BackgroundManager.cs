using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackgroundManager : MonoBehaviour
{
    public Image backgroundImage;
    public List<Sprite> imageList = new List<Sprite>();
    public static BackgroundManager Instance;

    public TextMeshProUGUI monthText;  
    private List<string> monthList = new List<string>
        {
            "March", "April", "May", "June", "July", "August", "September",
            "October", "November", "December", "January", "February"
        };
    private List<string> monthListFR = new List<string>
    {
        "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre",
        "Octobre", "Novembre", "Décembre", "Janvier", "Février"
    };

    // Variables to change the color according to the season
    public static Color32 normalColor;
    public static Color32 normalUpgradeColor;
    public static Color32 buyableUpgradeColor;

    private static Color32 SColor = new Color32(0,230,0,255);
    private static Color32 SNormalColor = new Color32(0,160,0,200);
    private static Color32 SBuyableUpgradeColor = new Color32(0,230,0,200);

    private static Color32 SuColor = new Color32(0,200,0,255);
    private static Color32 SuNormalColor = new Color32(10,135,0,200);
    private static Color32 SuBuyableUpgradeColor = new Color32(40,210,40,200);

    private static Color32 FColor = new Color32(255,121,0,200);
    private static Color32 FNormalColor = new Color32(255,0,0,170);
    private static Color32 FBuyableUpgradeColor = new Color32(255,121,0,200); 

    private static Color32 WColor = new Color32(60,180,255,200);
    private static Color32 WNormalColor = new Color32(0,70,200,200);
    private static Color32 WBuyableUpgradeColor = new Color32(60,180,255,200);

    private static List<Color32> colorList = new List<Color32> {SColor, SuColor, FColor, WColor};
    private static List<Color32> colorNormalList = new List<Color32> {SNormalColor, SuNormalColor, FNormalColor, WNormalColor};
    private static List<Color32> colorBuyableList = new List<Color32> {SBuyableUpgradeColor, SuBuyableUpgradeColor, FBuyableUpgradeColor, WBuyableUpgradeColor};

    int colorMonth;

    public Image ImagePointsPerSecond;
    public Image ImagePointsPerClick;
    public Image[] ImagesColor;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        backgroundImage.sprite = imageList[DataManager.playerData.indexBackgroundImage];
        colorMonth = DataManager.playerData.indexBackgroundImage / 3;
        normalColor = colorList[colorMonth];
        normalUpgradeColor = colorNormalList[colorMonth];
        buyableUpgradeColor = colorBuyableList[colorMonth];
        ImagePointsPerSecond.color = (DataManager.playerData.TotalPoints < Upgrades.CostPointsPerSecond) ? normalUpgradeColor : buyableUpgradeColor;
        ImagePointsPerClick.color = (DataManager.playerData.TotalPoints < Upgrades.CostPointsPerClick) ? normalUpgradeColor : buyableUpgradeColor;
        if (ImagesColor != null)
        {
            foreach (Image image in ImagesColor)
            {
                image.color = normalColor;
            }
        }
    }

    // Call this function to change the image to the next index in the list
    public void ShowNextMonth()
    {
        DataManager.playerData.indexBackgroundImage = (DataManager.playerData.indexBackgroundImage + 1) % imageList.Count;
        backgroundImage.sprite = imageList[DataManager.playerData.indexBackgroundImage];
        switch (DataManager.playerData.Language)
        {
            case "en":
                monthText.text = monthList[DataManager.playerData.indexBackgroundImage];
                break;
            case "fr":
                monthText.text = monthListFR[DataManager.playerData.indexBackgroundImage];
                break;
        }
        colorMonth = DataManager.playerData.indexBackgroundImage / 3;
        normalColor = colorList[colorMonth];
        normalUpgradeColor = colorNormalList[colorMonth];
        buyableUpgradeColor = colorBuyableList[colorMonth];
        ImagePointsPerSecond.color = (DataManager.playerData.TotalPoints < Upgrades.CostPointsPerSecond) ? normalUpgradeColor : buyableUpgradeColor;
        ImagePointsPerClick.color = (DataManager.playerData.TotalPoints < Upgrades.CostPointsPerClick) ? normalUpgradeColor : buyableUpgradeColor;
        if (ImagesColor != null)
        {
            foreach (Image image in ImagesColor)
            {
                image.color = normalColor;
            }
        }
    }
}
