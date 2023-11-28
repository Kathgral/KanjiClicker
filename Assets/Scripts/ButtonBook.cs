using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBook : MonoBehaviour
{
    public void AddClicksToManager(){
        Manager.instance.AddClicks();
    }
}