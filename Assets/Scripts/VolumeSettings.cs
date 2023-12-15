using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSourceBackground;
    public AudioSource audioSourceBook;
    public TextMeshProUGUI volumeValue;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        volumeSlider.value = DataManager.playerData.Volume;
        volumeValue.text = "" + DataManager.playerData.Volume;
    }

    void OnVolumeChanged(float volume)
    {
        volumeValue.text = "" + volume;
        float normalizedVolume = volume / 10.0f;
        audioSourceBackground.volume = normalizedVolume / 2;
        audioSourceBook.volume = normalizedVolume;
    }    
}

