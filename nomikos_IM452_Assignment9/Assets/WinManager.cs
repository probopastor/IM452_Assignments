using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    public int scoreToWin = 10;
    public int currentScore = 0;
    public Text scoreText;
    public GameObject winPanel;
    public bool gameWon;

    // Start is called before the first frame update
    void Start()
    {
        gameWon = false;
        winPanel.SetActive(false);
        currentScore = 0;
        scoreText.text = currentScore + " / " + scoreToWin + " Enemies Defeated";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = currentScore + " / " + scoreToWin + " Enemies Defeated";
    }

    public void UpdateScore()
    {
        currentScore++;
        if(currentScore >= scoreToWin)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        gameWon = true;
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
