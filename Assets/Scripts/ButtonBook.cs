using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBook : MonoBehaviour
{
    public AudioSource soundButton;

    public void AddClicksToManager(){
        GameManager.TotalClicks += GameManager.TotalClicksPerTap;
        soundButton.Play();
    }
}