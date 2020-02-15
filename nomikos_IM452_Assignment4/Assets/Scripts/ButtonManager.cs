/*
* William Nomikos
* ButtonManager.cs
* Assignment 4
* Script handles the functionality  and sound effects 
* of the pause menu and button presses within the game scene. 
* Handles main game UI.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private bool paused;

    public GameObject PauseCanvas;

    public AudioSource GameSource;
    public AudioClip gameMusic;

    public AudioSource SoundEffectSource;
    public AudioClip buttonClick;

    // Start is called before the first frame update
    void Start()
    {
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
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
        }
        else if (paused == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            paused = false;
            PauseCanvas.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonClick()
    {
        SoundEffectSource.clip = buttonClick;
        SoundEffectSource.Play();
    }
}
