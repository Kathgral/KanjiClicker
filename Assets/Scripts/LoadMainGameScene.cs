using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMainGameScene : MonoBehaviour
{
    AsyncOperation AO;
    bool canActivate = false;
    float activationTimer = 0.2f;

    void Start()
    {
        AO = SceneManager.LoadSceneAsync("MainGame", LoadSceneMode.Additive);
        AO.allowSceneActivation = false;
    }

    void Update()
    {
        if (!canActivate)
        {
            activationTimer -= Time.deltaTime;

            if (activationTimer <= 0.0f)
            {
                canActivate = true;
            }
        }

        if (canActivate && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            AO.allowSceneActivation = true;
        }
        if (SceneManager.GetSceneByName("MainGame").isLoaded)
        {
            SceneManager.UnloadSceneAsync("StartScreen");
        }
    }
}