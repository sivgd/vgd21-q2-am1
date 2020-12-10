using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject mainMenuUI;

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        pauseMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Continue()
    {
        Debug.Log("Starting Game");
        mainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game...");
    }
}