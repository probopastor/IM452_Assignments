using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Text waveTimeText;

    public Color clickedColor;
    public Color defaultColor;

    public int timeUntilButtonClick = 1;
    private int timeRemaining = 0;

    private Renderer buttonRend;
    public bool isClicked;
    public int waveNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        waveNumber = 0;
        buttonRend = gameObject.GetComponent<Renderer>();
        buttonRend.material.color = defaultColor;
        timeRemaining = timeUntilButtonClick;
        waveTimeText.text = "Wave Time Left: " + timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        waveTimeText.text = "Wave Time Left: " + timeRemaining;
    }

    public void ClickButton()
    {
        if(!isClicked)
        {
            isClicked = true;
            buttonRend.material.color = clickedColor;

            timeRemaining = timeUntilButtonClick;
            waveNumber++;

            if(waveNumber <= 3)
            {
                StartCoroutine("ButtonTimer");
            }
            else if(waveNumber > 3)
            {
                WinGame();
            }
        }
    }

    public IEnumerator ButtonTimer()
    {
        if(timeRemaining > 0)
        {
            timeRemaining--;
            yield return new WaitForSeconds(1);
            StartCoroutine("ButtonTimer");
        }
        else
        {
            yield return new WaitForSeconds(1);
            timeRemaining = timeUntilButtonClick;
            buttonRend.material.color = defaultColor;
            isClicked = false;
        }
    }

    private void WinGame()
    {
        Debug.Log("Game Won ");
    }
}
