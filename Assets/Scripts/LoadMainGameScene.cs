using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMainGameScene : MonoBehaviour
{
    AsyncOperation AO;
    void Start()
    {
        AO = SceneManager.LoadSceneAsync("MainGame", LoadSceneMode.Additive);
        AO.allowSceneActivation = false;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            AO.allowSceneActivation = true;
        }
        if (SceneManager.GetSceneByName("MainGame").isLoaded)
        {
            SceneManager.UnloadSceneAsync("StartScreen");
        }
    }
}