using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawning : MonoBehaviour
{
    public GameObject[] obstacleArray;
    public Vector3[] spawnPos;
    public float[] obstacleSpawningTime;

    public Text tutorialText;
    public GameObject spaceIcon;
    public GameObject dIcon;
    public GameObject aIcon;
    public GameObject rightArrowIcon;
    public GameObject leftArrowIcon;


    public GameObject enterIcon;
    public GameObject escapeIcon;

    public GameObject spikeIcon;
    public GameObject coinIcon;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        spaceIcon.SetActive(false);

        dIcon.SetActive(false);
        aIcon.SetActive(false);

        rightArrowIcon.SetActive(false);
        leftArrowIcon.SetActive(false);

        spikeIcon.SetActive(false);
        coinIcon.SetActive(false);

        tutorialText.text = " ";

        StartCoroutine("Tutorial");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnObstaclePatterns()
    {
        index = Random.Range(0, obstacleArray.Length);

        yield return new WaitForSeconds(1f);
        Instantiate(obstacleArray[index], new Vector3(gameObject.transform.position.x, spawnPos[index].y, spawnPos[index].z), Quaternion.identity);
        yield return new WaitForSeconds(obstacleSpawningTime[index]);
        StartCoroutine("SpawnObstaclePatterns");
    }

    private IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "Welcome to Multidimensional Cube the Fourth! ";
        yield return new WaitForSeconds(3f);
        tutorialText.text = "Press SPACE to jump ";
        spaceIcon.SetActive(true);
        yield return new WaitForSeconds(3f);

        spaceIcon.SetActive(false);
        tutorialText.text = "Use D to move right and A to move left ";
        aIcon.SetActive(true);
        dIcon.SetActive(true);
        yield return new WaitForSeconds(3f);

        aIcon.SetActive(false);
        dIcon.SetActive(false);
        tutorialText.text = "Press Enter to switch between dimensions! ";
        enterIcon.SetActive(true);
        yield return new WaitForSeconds(3f);

        enterIcon.SetActive(false);
        spikeIcon.SetActive(true);
        tutorialText.text = "If you hit a spike, you will die. Don't hit spikes. ";
        yield return new WaitForSeconds(3f);

        tutorialText.text = "In the upsidown dimension, spikes will pulse between existing and not existing... ";
        yield return new WaitForSeconds(3f);

        tutorialText.text = "Luckily, they leave behind a transparent shadow of where they will reappear at! You can touch this, it is simply an indicator of where the spike is. ";
        yield return new WaitForSeconds(3f);

        spikeIcon.SetActive(false);
        coinIcon.SetActive(true);
        tutorialText.text = "To win, collect 5 coins. Coins may not always appear in easy to reach places, so good luck! ";
        yield return new WaitForSeconds(3f);

        coinIcon.SetActive(false);
        //SET CONTROL PANEL ACTIVE HERE
        //SET SCORE COUNTER ACTIVE HERE
        tutorialText.text = "Ready? ";
        yield return new WaitForSeconds(3f);

        tutorialText.text = "Go! ";
        yield return new WaitForSeconds(3f);

        tutorialText.text = " ";
        StartCoroutine("SpawnObstaclePatterns");
    }
}
