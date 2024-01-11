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

    // Variables to change the color according to the season
    public static Color32 normalColor;
    public static Color32 normalUpgradeColor;
    public static Color32 buyableUpgradeColor;

    private static Color32 SColor = new Color32(0,200,0,255);
    private static Color32 SNormalColor = new Color32(7,135,0,200);
    private static Color32 SBuyableUpgradeColor = new Color32(0,230,0,200);

    private static Color32 FColor = new Color32(255,121,0,200);
    private static Color32 FNormalColor = new Color32(255,0,0,170);
    private static Color32 FBuyableUpgradeColor = new Color32(255,121,0,200); 

    private static Color32 WColor = new Color32(60,180,255,200);
    private static Color32 WNormalColor = new Color32(0,70,200,200);
    private static Color32 WBuyableUpgradeColor = new Color32(60,180,255,200);

    private static List<Color32> colorList = new List<Color32> {SColor, SColor, FColor, WColor};
    private static List<Color32> colorNormalList = new List<Color32> {SNormalColor, SNormalColor, FNormalColor, WNormalColor};
    private static List<Color32> colorBuyableList = new List<Color32> {SBuyableUpgradeColor, SBuyableUpgradeColor, FBuyableUpgradeColor, WBuyableUpgradeColor};

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
        monthText.text = monthList[DataManager.playerData.indexBackgroundImage];
        colorMonth = DataManager.playerData.indexBackgroundImage / 3;
        normalColor = colorList[colorMonth];
        normalUpgradeColor = colorNormalList[colorMonth];
        buyableUpgradeColor = colorBuyableList[colorMonth];
        ImagePointsPerSecond.color = (DataManager.playerData.TotalPoints < Uprgrade2Button.CostPointsPerSecond) ? normalUpgradeColor : buyableUpgradeColor;
        ImagePointsPerClick.color = (DataManager.playerData.TotalPoints < Uprgrade2Button.CostPointsPerClick) ? normalUpgradeColor : buyableUpgradeColor;
        if (ImagesColor != null)
        {
            foreach (Image image in ImagesColor)
            {
                image.color = normalColor;
            }
        }
    }

    // Call this function to change the image to the next index in the list
    public void ShowNextImage()
    {
        DataManager.playerData.indexBackgroundImage = (DataManager.playerData.indexBackgroundImage + 1) % imageList.Count;
        backgroundImage.sprite = imageList[DataManager.playerData.indexBackgroundImage];
        monthText.text = monthList[DataManager.playerData.indexBackgroundImage];
        colorMonth = DataManager.playerData.indexBackgroundImage / 3;
        normalColor = colorList[colorMonth];
        normalUpgradeColor = colorNormalList[colorMonth];
        buyableUpgradeColor = colorBuyableList[colorMonth];
        ImagePointsPerSecond.color = (DataManager.playerData.TotalPoints < Uprgrade2Button.CostPointsPerSecond) ? normalUpgradeColor : buyableUpgradeColor;
        ImagePointsPerClick.color = (DataManager.playerData.TotalPoints < Uprgrade2Button.CostPointsPerClick) ? normalUpgradeColor : buyableUpgradeColor;
        if (ImagesColor != null)
        {
            foreach (Image image in ImagesColor)
            {
                image.color = normalColor;
            }
        }
    }
}
