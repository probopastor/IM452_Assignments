/*
* William Nomikos
* ScoreManager.cs
* Assignment 11
* Handles the game's scoring.
*/

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
        currentScore = 0;
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
