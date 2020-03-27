/*
* William Nomikos
* PauseManager.cs
* Assignment 8
* Handles In-Game pause menu and functionality, including restarting, exiting
* to main menu, button sound effects and game music.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public bool paused;

    public GameObject PauseCanvas;

    public AudioSource GameSource;
    public AudioClip gameMusic;

    public AudioSource SoundEffectSource;
    public AudioClip buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        paused = false;
        PauseCanvas.SetActive(false);

        GameSource.clip = gameMusic;
        GameSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (paused == false)
        {
            paused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
        }
        else if (paused == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 1;
            paused = false;
            PauseCanvas.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("SampleScene");
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonClick()
    {
        SoundEffectSource.clip = buttonClick;
        SoundEffectSource.Play();
    }
}
