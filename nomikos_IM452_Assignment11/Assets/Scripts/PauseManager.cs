﻿/*
* William Nomikos
* PauseManager.cs
* Assignment 11
* Handles pause menu functionality, including pausing the game,
* unpausing the game, restarting the game, and quitting to the 
* main menu. Also handles enabling win and lose panels.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool paused;
    public bool gameLost;

    public string thisScene;

    public GameObject PauseCanvas;
    public GameObject LoseCanvas;
    public GameObject WinCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameLost = false;

        paused = false;
        PauseCanvas.SetActive(false);
        LoseCanvas.SetActive(false);
        WinCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameLost)
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (paused == false)
        {
            paused = true;
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
        }
        else if (paused == true)
        {
            Time.timeScale = 1;
            paused = false;
            PauseCanvas.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(thisScene);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void SetGameLost()
    {
        gameLost = true;
        LoseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetGameWin()
    {
        WinCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
