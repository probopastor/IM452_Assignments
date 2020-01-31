using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    private bool paused;

    public GameObject PauseCanvas;


    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        PauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if(paused == false)
        {
            paused = true;
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
        }
        else if(paused == true)
        {
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


}
