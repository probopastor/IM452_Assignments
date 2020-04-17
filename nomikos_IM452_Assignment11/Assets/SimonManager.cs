using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonManager : MonoBehaviour
{
    private PlayerController playerObject;
    private ScoreManager scoreManager;

    public List<GameObject> tracks = new List<GameObject>();
    private int currentIndex = 0;

    public float secondsBetweenMovements = 1f;
    private int amountOfMoves = 0;
    private float timeToWait = 4f;

    private bool currentlyPerformingAction = false;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = FindObjectOfType<PlayerController>();
        scoreManager = FindObjectOfType<ScoreManager>();

        scoreManager.ResetScore();
    }

    // Update is called once per frame
    void Update()
    {        
        MovementAmount();

        if(!currentlyPerformingAction)
        {
            Debug.Log("Action starting");
            scoreManager.IncreaseLevel();
            currentlyPerformingAction = true;
            StartCoroutine(TimeBeforeNextWave());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

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
    }

    private IEnumerator TimeBeforeNextWave()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(timeToWait);
        StartCoroutine(PerformAction(amountOfMoves));
    }

    private IEnumerator PerformAction(int timesToPerform)
    {
        Debug.Log("Performing: " + timesToPerform + " many times");
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

        currentlyPerformingAction = false;
    }
}
