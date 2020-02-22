/*
* William Nomikos
* PauseManager.cs
* Assignment 5
* Handles pause in-game pause menu functionality and button functionality,
* along with game music.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    private bool paused;

    public GameObject PauseCanvas;
    public GameObject crosshair;

    public AudioSource GameSource;
    public AudioClip gameMusic;

    public AudioSource SoundEffectSource;
    public AudioClip buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        PauseCanvas.SetActive(false);
        crosshair.SetActive(true);

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
            crosshair.SetActive(false);
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
            crosshair.SetActive(true);
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
