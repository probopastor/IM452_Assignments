using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Text tutorialText;
    public Text tutorialSkipText;

    public AudioSource SoundEffectSource;
    public AudioClip clickSound;

    public GameObject swordPanel;
    public GameObject controlPanel;
    public GameObject enemiesLeft;
    public GameObject healthText;

    // Start is called before the first frame update
    void Start()
    {
        tutorialText.text = " ";
        tutorialSkipText.text = " ";

        swordPanel.SetActive(false);
        controlPanel.SetActive(false);
        enemiesLeft.SetActive(false);
        healthText.SetActive(false);

        StartCoroutine(TutorialText());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            StopCoroutine("TutorialText");
            tutorialText.text = " ";
            tutorialSkipText.text = " ";

            swordPanel.SetActive(true);
            controlPanel.SetActive(true);
            enemiesLeft.SetActive(true);
            healthText.SetActive(true);

            StartCoroutine(SpawnEnemy());
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
    }
}
