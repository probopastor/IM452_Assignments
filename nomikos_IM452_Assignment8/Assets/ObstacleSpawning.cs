using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawning : MonoBehaviour
{
    private PlayerController playerController;

    public GameObject[] obstacleArray;
    public Vector3[] spawnPos;
    public float[] obstacleSpawningTime;

    public GameObject controlPanel;

    public Text tutorialText;
    public GameObject spaceIcon;
    public GameObject dIcon;
    public GameObject aIcon;

    public GameObject enterIcon;
    public GameObject escapeIcon;

    public GameObject spikeIcon;
    public GameObject transparentSpikeIcon;
    public GameObject coinIcon;

    private int index = 0;

    private bool controlPanelActive = false;
    private bool doOnce = false;

    public AudioSource SoundEffectSource;
    public AudioClip textSwitchClip;
    public AudioClip startGameClip;

    private bool inTutorial = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        controlPanel.SetActive(true);
        controlPanelActive = true;

        spaceIcon.SetActive(false);

        dIcon.SetActive(false);
        aIcon.SetActive(false);

        spikeIcon.SetActive(false);
        coinIcon.SetActive(false);

        transparentSpikeIcon.SetActive(false);

        tutorialText.text = " ";

        StartCoroutine("Tutorial");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            if(inTutorial)
            {
                inTutorial = false;

                StopCoroutine("Tutorial");

                tutorialText.text = " ";

                controlPanelActive = true;

                spaceIcon.SetActive(false);

                dIcon.SetActive(false);
                aIcon.SetActive(false);

                spikeIcon.SetActive(false);
                coinIcon.SetActive(false);

                transparentSpikeIcon.SetActive(false);

                SoundEffectSource.clip = startGameClip;
                SoundEffectSource.Play();

                StartCoroutine("SpawnObstaclePatterns");
            }
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            if(controlPanelActive)
            {
                controlPanel.SetActive(false);
                controlPanelActive = false;
            }
            else if(!controlPanelActive)
            {
                controlPanel.SetActive(true);
                controlPanelActive = true;
            }
        }
    }

    private void EnableCoinText()
    {
        if (!doOnce)
        {
            playerController.SetCoinTextActive();
            doOnce = true;
        }
    }

    private IEnumerator SpawnObstaclePatterns()
    {
        EnableCoinText();

        index = Random.Range(0, obstacleArray.Length);

        yield return new WaitForSeconds(1f);
        Instantiate(obstacleArray[index], new Vector3(gameObject.transform.position.x, spawnPos[index].y, spawnPos[index].z), Quaternion.identity);
        yield return new WaitForSeconds(obstacleSpawningTime[index]);
        StartCoroutine("SpawnObstaclePatterns");
    }

    private IEnumerator Tutorial()
    {
        inTutorial = true;

        SoundEffectSource.clip = textSwitchClip;

        yield return new WaitForSeconds(0.5f);
        SoundEffectSource.Play();
        tutorialText.text = "Welcome to Multidimensional Cube the Fourth! ";
        yield return new WaitForSeconds(3f);

        SoundEffectSource.Play();
        tutorialText.text = "Press 1 to Skip the Tutorial! ";
        yield return new WaitForSeconds(3f);

        SoundEffectSource.Play();
        tutorialText.text = "Press H to toggle the control panel on and off ";
        yield return new WaitForSeconds(3f);

        SoundEffectSource.Play();
        tutorialText.text = "Press SPACE to jump ";
        spaceIcon.SetActive(true);
        yield return new WaitForSeconds(3f);

        spaceIcon.SetActive(false);
        SoundEffectSource.Play();
        tutorialText.text = "Use D to move right and A to move left ";
        aIcon.SetActive(true);
        dIcon.SetActive(true);
        yield return new WaitForSeconds(3f);

        aIcon.SetActive(false);
        dIcon.SetActive(false);
        SoundEffectSource.Play();
        tutorialText.text = "Press Enter to switch between dimensions! ";
        enterIcon.SetActive(true);
        yield return new WaitForSeconds(3f);

        enterIcon.SetActive(false);
        spikeIcon.SetActive(true);
        SoundEffectSource.Play();
        tutorialText.text = "If you hit a spike, you will die. Don't hit spikes. ";
        yield return new WaitForSeconds(5f);

        SoundEffectSource.Play();
        tutorialText.text = "In the upsidown dimension, spikes will pulse between existing and not existing... ";
        yield return new WaitForSeconds(5f);

        spikeIcon.SetActive(false);
        transparentSpikeIcon.SetActive(true);
        SoundEffectSource.Play();
        tutorialText.text = "Luckily, they leave behind a transparent shadow of where they will reappear at! You can touch this, it is simply an indicator of where the spike is. ";
        yield return new WaitForSeconds(5f);

        transparentSpikeIcon.SetActive(false);
        coinIcon.SetActive(true);
        SoundEffectSource.Play();
        tutorialText.text = "To win, collect 5 coins. Coins may not always appear in easy to reach places, so good luck! ";
        yield return new WaitForSeconds(5f);

        coinIcon.SetActive(false);

        EnableCoinText();

        SoundEffectSource.Play();
        tutorialText.text = "Ready? ";
        yield return new WaitForSeconds(3f);

        SoundEffectSource.clip = startGameClip;
        SoundEffectSource.Play();
        tutorialText.text = "Go! ";
        inTutorial = false;
        yield return new WaitForSeconds(3f);

        tutorialText.text = " ";
        StartCoroutine("SpawnObstaclePatterns");
    }
}
