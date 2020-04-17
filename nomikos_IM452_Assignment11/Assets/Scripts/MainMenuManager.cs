/*
* William Nomikos
* MainMenuManager.cs
* Assignment 11
* Handles Main Menu functionality, including starting and quitting the game.
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

