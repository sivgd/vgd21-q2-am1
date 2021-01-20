using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartLevelOne()
    {
        SceneManager.LoadScene("Demo");
        CabbageCounter.cabbageAmount = 0;
        WaveCounter.waveNumber = 0;
        Resume();
        Debug.Log("Restarting Level One...");
    }
    public void RestartLeveTwo()
    {
        SceneManager.LoadScene("Level2");
        CabbageCounter.cabbageAmount = 0;
        WaveCounter.waveNumber = 0;
        Resume();
        Debug.Log("Restarting Level Two...");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Resume();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
        Resume();
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Demo");
        CabbageCounter.cabbageAmount = 0;
        WaveCounter.waveNumber = 0;
        Resume();
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level2");
        CabbageCounter.cabbageAmount = 0;
        WaveCounter.waveNumber = 0;
        Resume();
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");

    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}