/*
* William Nomikos
* ImpactText.cs
* Assignment 4
* This script handles the impact timer and win condition 
* of the game. Decreases impact timer and when it hits 0, 
* lets the player win the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImpactText : MonoBehaviour
{
    public GameObject winPanel;
    public float timeToWin = 0f;
    public Text thisText;
    private bool isWon = false;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        isWon = false;
        thisText.enabled = true;
        thisText.text = "Impact in " + timeToWin;

        StartCoroutine("TimeCount");
    }

    private IEnumerator TimeCount()
    {
        timeToWin--;
        thisText.text = "Impact in " + timeToWin;

        yield return new WaitForSeconds(1f);

        if(timeToWin == 110)
        {
            ObjectSpawner.firstIt = true;
        }
        else if(timeToWin == 100)
        {
            ObjectSpawner.firstIt = true;
        }
        else if (timeToWin == 90)
        {
            ObjectSpawner.firstIt = true;
        }
        else if (timeToWin == 80)
        {
            ObjectSpawner.firstIt = true;
        }
        else if (timeToWin == 70)
        {
            ObjectSpawner.firstIt = true;
        }
        else if (timeToWin == 60)
        {
            ObjectSpawner.firstIt = true;
        }
        else if (timeToWin == 50)
        {
            ObjectSpawner.firstIt = true;
        }
        else if (timeToWin == 40)
        {
            ObjectSpawner.firstIt = true;
        }
        else if (timeToWin == 30)
        {
            ObjectSpawner.firstIt = true;
        }
        else if (timeToWin == 20)
        {
            ObjectSpawner.firstIt = true;
        }
        else if (timeToWin == 10)
        {
            ObjectSpawner.firstIt = true;
        }

        if (timeToWin <= 0)
        {
            timeToWin = 0;

            if (!isWon)
            {
                isWon = true;
                StartCoroutine("WinGame");
            }
        }
        else
        {
            StartCoroutine("TimeCount");
        }

    }

    private IEnumerator WinGame()
    {
        yield return new WaitForSeconds(0.5f);

        thisText.enabled = false;
        winPanel.SetActive(true);

        Time.timeScale = 0;
    }
}
