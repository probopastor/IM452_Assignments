﻿/*
* William Nomikos
* MainMenuManager.cs
* Assignment 4
* Script handles the music and UI sound effects in the Main Menu.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource GameSource;
    public AudioClip gameMusic;

    public AudioSource SoundEffectSource;
    public AudioClip buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        GameSource.clip = gameMusic;
        GameSource.Play();
    }

    public void StartGame()
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
