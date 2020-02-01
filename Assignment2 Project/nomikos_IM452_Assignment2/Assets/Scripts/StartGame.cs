using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource MainMenuSource;
    public AudioClip menuMusic;

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
}
