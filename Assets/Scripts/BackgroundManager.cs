using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Image backgroundImage;
    public List<Sprite> imageList = new List<Sprite>();
    public static BackgroundManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        backgroundImage.sprite = imageList[DataManager.playerData.indexBackgroundImage];
    }

    // Call this function to change the image to the next index in the list
    public void ShowNextImage()
    {
        DataManager.playerData.indexBackgroundImage = (DataManager.playerData.indexBackgroundImage + 1) % imageList.Count;
        backgroundImage.sprite = imageList[DataManager.playerData.indexBackgroundImage];
    }
}
