using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void Start()
    {
        Debug.Log("Starting Game");
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game...");
    }
}