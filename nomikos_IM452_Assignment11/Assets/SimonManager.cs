using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonManager : MonoBehaviour
{
    private PlayerController playerObject;
    private ScoreManager scoreManager;

    private Queue<GameObject> objectOrder = new Queue<GameObject>();

    public List<GameObject> tracks = new List<GameObject>();
    private int currentIndex = 0;

    public float secondsBetweenMovements = 1f;
    private int amountOfMoves = 0;
    private float timeToWait = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = FindObjectOfType<PlayerController>();
        scoreManager = FindObjectOfType<ScoreManager>();

        scoreManager.ResetScore();

        StartCoroutine(PerformAction());
    }

    // Update is called once per frame
    void Update()
    {
        //playerObject.ObjectsToTouch(objectOrder);
        
        MovementAmount();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectOrder.Enqueue(collision.gameObject);
    }

    private void MovementAmount()
    {
        if(scoreManager.GetLevel() == 1)
        {
            amountOfMoves = 2;
            timeToWait = 1f;
        }
        else if(scoreManager.GetLevel() == 2)
        {
            amountOfMoves = 3;
            timeToWait = 1f;
        }
        else if (scoreManager.GetLevel() == 3)
        {
            amountOfMoves = 4;
            timeToWait = 1f;
        }
        else if (scoreManager.GetLevel() == 4)
        {
            amountOfMoves = 5;
            timeToWait = 1f;
        }
        else if (scoreManager.GetLevel() == 5)
        {
            amountOfMoves = 6;
            timeToWait = 1f;
        }
        else if (scoreManager.GetLevel() == 6)
        {
            amountOfMoves = 7;
            timeToWait = 1f;
        }
        else if (scoreManager.GetLevel() == 7)
        {
            amountOfMoves = 8;
            timeToWait = 1f;
        }
    }

    private IEnumerator PerformAction()
    {
        scoreManager.IncreaseLevel();

        for (int i = 0; i <= amountOfMoves; i++)
        {
            int randomInt = Random.Range(0, 3);
            yield return new WaitForSeconds(secondsBetweenMovements);

            if (randomInt == 0)
            {
                transform.position = new Vector3(tracks[currentIndex].transform.position.x, transform.position.y, transform.position.z);
            }
            else if (randomInt == 1)
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
        yield return new WaitForSeconds(timeToWait);
        //StartCoroutine(PerformAction());
    }
}
