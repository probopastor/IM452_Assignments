/*
* William Nomikos
* EnemySpawner.cs
* Assignment 9
* Handles the spawning of enemies at spawn points and the 
* tutorial at the start of the game. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] spawnLocations;

    public Text tutorialText;
    public Text tutorialSkipText;

    public AudioSource SoundEffectSource;
    public AudioClip clickSound;

    public GameObject swordPanel;
    public GameObject controlPanel;
    public GameObject enemiesLeft;
    public GameObject healthText;

    public GameObject strongEnemyIcon;
    public GameObject mediumEnemyIcon;
    public GameObject weakEnemyIcon;


    private bool doOnce = false;

    private IEnumerator coroutine;

    private int index;
    private int locationIndex;

    // Start is called before the first frame update
    void Start()
    {
        coroutine = TutorialText();

        index = 0;
        locationIndex = 0;

        doOnce = false;
        tutorialText.text = " ";
        tutorialSkipText.text = " ";

        swordPanel.SetActive(false);
        controlPanel.SetActive(false);
        enemiesLeft.SetActive(false);
        healthText.SetActive(false);
        strongEnemyIcon.SetActive(false);
        mediumEnemyIcon.SetActive(false);
        weakEnemyIcon.SetActive(false);

        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if (!doOnce)
            {
                doOnce = true;

                StopCoroutine(coroutine);
                tutorialText.text = " ";
                tutorialSkipText.text = " ";

                swordPanel.SetActive(true);
                controlPanel.SetActive(true);
                enemiesLeft.SetActive(true);
                healthText.SetActive(true);
                strongEnemyIcon.SetActive(false);
                mediumEnemyIcon.SetActive(false);
                weakEnemyIcon.SetActive(false);

                StartCoroutine(SpawnEnemy());
            }
        }
    }

    private IEnumerator TutorialText()
    {
        SoundEffectSource.clip = clickSound;

        SoundEffectSource.Play();
        tutorialText.text = " Welcome to Magical Sword Woah! ";
        yield return new WaitForSeconds(2f);

        SoundEffectSource.Play();
        tutorialSkipText.text = "Press X to skip the tutorial! ";
        tutorialText.text = "Use WASD to move around. ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        tutorialText.text = "You have a magical sword that can do many things. ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        tutorialText.text = "Move your mouse to swing your sword. ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        swordPanel.SetActive(true);
        tutorialText.text = "When you press 1, the sword will simply be a powerful sword! ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        tutorialText.text = "When you press 2, hitting an enemy with the sword will light them on fire! ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        tutorialText.text = "When an enemy is on fire, it will burn for a short period of time. ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        tutorialText.text = "Enemies that are on fire will have red flames surrounding them. ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        tutorialText.text = "When you press 3, hitting an enemy with the sword will stun the enemy! ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        tutorialText.text = "When an enemy is stunned, they will not move for a short period of time. ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        tutorialText.text = "Stunned enemies will have yellow sparks around them. ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        tutorialText.text = "Stunned enemies will have yellow sparks around them. ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        tutorialText.text = "Enemies will spawn over time from the right, left, and top of the screen. ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        healthText.SetActive(true);
        tutorialText.text = "If an enemy touches you, they will damage you. When your life reaches 0, you die and lose! ";
        yield return new WaitForSeconds(5f);

        SoundEffectSource.Play();
        weakEnemyIcon.SetActive(true);
        tutorialText.text = "Weak enemies are fast but do little damage. Weak enemies do not have much health. They take long time to recover from a stun. ";
        yield return new WaitForSeconds(5f);

        SoundEffectSource.Play();
        weakEnemyIcon.SetActive(false);
        mediumEnemyIcon.SetActive(true);
        tutorialText.text = "Medium enemies are slightly slower than weak enemies but they deal more damage. They have a medium amount of health. They recover from stuns faster than weak enemies as well. ";
        yield return new WaitForSeconds(7f);

        SoundEffectSource.Play();
        mediumEnemyIcon.SetActive(false);
        strongEnemyIcon.SetActive(true);
        tutorialText.text = "Strong enemies are very slow but deal lots of damage. They recover from stuns almost instantly and have lots of health. ";
        yield return new WaitForSeconds(7f);

        SoundEffectSource.Play();
        strongEnemyIcon.SetActive(false);
        enemiesLeft.SetActive(true);
        tutorialText.text = "Kill 20 enemies to win! ";
        yield return new WaitForSeconds(4f);

        SoundEffectSource.Play();
        controlPanel.SetActive(true);
        tutorialText.text = "Ready? ";
        yield return new WaitForSeconds(2f);

        tutorialSkipText.text = " ";

        SoundEffectSource.Play();
        tutorialText.text = "Begin! ";
        yield return new WaitForSeconds(2f);
        tutorialText.text = " ";

        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);

        int randomEnemySpawnNumber = Random.Range(0, 3);

        for(int i = 0; i <= randomEnemySpawnNumber; i++)
        {
            index = Random.Range(0, enemies.Length);
            locationIndex = Random.Range(0, spawnLocations.Length);
            Instantiate(enemies[index], spawnLocations[locationIndex].transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(SpawnEnemy());
    }
}
