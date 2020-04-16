using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int currentScore = 1;

    public void ResetScore()
    {
        currentScore = 6;
        scoreText.text = "Level: " + currentScore;
    }

    public void IncreaseLevel()
    {
        currentScore++;
        scoreText.text = "Level: " + currentScore;
    }

    public int GetLevel()
    {
        return currentScore;
    }
}
