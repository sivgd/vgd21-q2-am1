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

    public void Restart()
    {
        Debug.Log("Restarting Game...");
        CabbageCounter.cabbageAmount = 0;
        WaveCounter.waveNumber = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameIsPaused = false;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Demo");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("");
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}