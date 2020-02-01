/*
* William Nomikos
* StartGame.cs
* Assignment 2
* Script handles main menu UI and functions, including the ability to start the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource MainMenuSource;
    public AudioClip menuMusic;

    public AudioSource SoundEffectSource;
    public AudioClip buttonClick;

    private void Start()
    {
        MainMenuSource.clip = menuMusic;
        MainMenuSource.Play();
    }
    public void StartTheGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void ButtonClick()
    {
        SoundEffectSource.clip = buttonClick;
        SoundEffectSource.Play();
    }
}
