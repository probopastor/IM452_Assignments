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
