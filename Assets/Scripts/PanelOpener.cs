using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public void OpenPanel()
    {
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }

    public GameObject ClicksPanel;
    public void OpenClicksPanel()
    {
        if(ClicksPanel != null)
        {
            bool isActive = ClicksPanel.activeSelf;

            ClicksPanel.SetActive(!isActive);
        }
    }
}
