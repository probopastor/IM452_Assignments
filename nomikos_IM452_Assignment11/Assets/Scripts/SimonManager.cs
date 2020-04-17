/*
* William Nomikos
* SimonManager.cs
* Assignment 11
* Handles Simon's actions on his turn. Also acts as the facade driver, 
* determining which methods in object references need to be called.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonManager : MonoBehaviour
{
    private PlayerController playerObject;
    private ScoreManager scoreManager;
    private GameText gameText;

    public List<GameObject> tracks = new List<GameObject>();
    private int currentIndex = 0;

    public float secondsBetweenMovements = 1f;
    private int amountOfMoves = 0;
    private float timeToWait = 4f;

    private bool currentlyPerformingAction = false;

    public List<string> objectOrder = new List<string>();

    private bool firstRound;
    private bool firstObjectEncountered;

    public Color activeObjectColor;
    private PauseManager pauseManager;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = FindObjectOfType<PlayerController>();
        scoreManager = FindObjectOfType<ScoreManager>();
        gameText = FindObjectOfType<GameText>();
        pauseManager = FindObjectOfType<PauseManager>();

        gameText.EnableText(true);
        playerObject.CanPlayerMove(false);

        scoreManager.ResetScore();
        firstRound = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovementAmount();

        if(firstRound)
        {
            firstRound = false;
            scoreManager.IncreaseLevel();
            currentlyPerformingAction = true;
            StartCoroutine(TimeBeforeNextWave());
        }
        else if(!currentlyPerformingAction && playerObject.PlayerFinished())
        {
            currentlyPerformingAction = true;
            objectOrder = new List<string>();
            playerObject.ResetIndex();
            scoreManager.IncreaseLevel();
            StartCoroutine(TimeBeforeNextWave());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!firstObjectEncountered)
        {
            firstObjectEncountered = true;
            collision.gameObject.GetComponent<ObjectColor>().SetActiveColor(activeObjectColor);
        }
        else
        {
            if(collision.gameObject.CompareTag("Circle") || collision.gameObject.CompareTag("Square") || collision.gameObject.CompareTag("Polygon"))
            {
                objectOrder.Add(collision.gameObject.tag);
                collision.gameObject.GetComponent<ObjectColor>().SetActiveColor(activeObjectColor);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<ObjectColor>().SetDeactiveColor();
    }

    private void MovementAmount()
    {
        if(scoreManager.GetLevel() == 1)
        {
            amountOfMoves = 2;
        }
        else if(scoreManager.GetLevel() == 2)
        {
            amountOfMoves = 3;
        }
        else if (scoreManager.GetLevel() == 3)
        {
            amountOfMoves = 4;
        }
        else if (scoreManager.GetLevel() == 4)
        {
            amountOfMoves = 5;
        }
        else if (scoreManager.GetLevel() == 5)
        {
            amountOfMoves = 6;
        }
        else if (scoreManager.GetLevel() == 6)
        {
            amountOfMoves = 7;
        }
        else if (scoreManager.GetLevel() == 7)
        {
            amountOfMoves = 8;
        }
        else if (scoreManager.GetLevel() > 7)
        {
            pauseManager.SetGameWin();
        }
    }

    private IEnumerator TimeBeforeNextWave()
    {
        yield return new WaitForSeconds(timeToWait);
        StartCoroutine(PerformAction(amountOfMoves));
    }

    private IEnumerator PerformAction(int timesToPerform)
    {
        gameText.EnableText(true);
        playerObject.CanPlayerMove(false);
        int randomInt = 0;

        for(int i = 0; i <= timesToPerform; i++)
        {
            randomInt = Random.Range(1, 3);     

            yield return new WaitForSeconds(secondsBetweenMovements);

            if (randomInt == 1)
            {
                if (currentIndex + 1 <= tracks.Count - 1)
                {
                    currentIndex = currentIndex + 1;
                    transform.position = new Vector3(tracks[currentIndex].transform.position.x, transform.position.y, transform.position.z);
                }
                else
                {
                    currentIndex = currentIndex - 1;
                    transform.position = new Vector3(tracks[currentIndex].transform.position.x, transform.position.y, transform.position.z);
                }
            }
            else if (randomInt == 2)
            {
                if (currentIndex - 1 >= 0)
                {
                    currentIndex = currentIndex - 1;
                    transform.position = new Vector3(tracks[currentIndex].transform.position.x, transform.position.y, transform.position.z);
                }
                else
                {
                    currentIndex = currentIndex + 1;
                    transform.position = new Vector3(tracks[currentIndex].transform.position.x, transform.position.y, transform.position.z);
                }
            }
        }

        playerObject.ObjectsToTouch(objectOrder);
        gameText.EnableText(false);
        playerObject.CanPlayerMove(true);
        currentlyPerformingAction = false;
    }
}
