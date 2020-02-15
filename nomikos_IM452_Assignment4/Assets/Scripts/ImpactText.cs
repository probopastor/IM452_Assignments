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
        Debug.Log("You Won!");

        thisText.enabled = false;
        winPanel.SetActive(true);

        Time.timeScale = 0;
    }
}
