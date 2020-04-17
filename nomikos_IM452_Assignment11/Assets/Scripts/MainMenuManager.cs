/*
* William Nomikos
* MainMenuManager.cs
* Assignment 10
* Handles Main Menu button and sound functionality, including starting
* the game and quitting the game. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string sceneToLoad;

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

