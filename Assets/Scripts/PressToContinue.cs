using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToContinue : MonoBehaviour
{
    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Load the main game scene
            SceneManager.LoadScene("MainGame");
        }
    }
}
