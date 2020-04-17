using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text tutorialText;
    public Text tutorialSkipText;
    public string sceneToLoad;

    public GameObject scoreText;
    public GameObject simonObject;
    public GameObject playerObject;

    public GameObject shape1;
    public GameObject shape2;
    public GameObject shape3;

    public GameObject shape4;
    public GameObject shape5;
    public GameObject shape6;

    public GameObject simonText;
    public GameObject playerText;


    private IEnumerator coroutine;
    private bool doOnce;

    void Start()
    {
        scoreText.SetActive(false);
        simonObject.SetActive(false);
        playerObject.SetActive(false);

        playerText.SetActive(false);
        simonText.SetActive(false);

        shape1.SetActive(false);
        shape2.SetActive(false);
        shape3.SetActive(false);

        shape4.SetActive(false);
        shape5.SetActive(false);
        shape6.SetActive(false);


        coroutine = TutorialText();
        doOnce = false;
        StartCoroutine(coroutine);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!doOnce)
            {
                doOnce = true;

                StopCoroutine(coroutine);
                tutorialText.text = " ";
                tutorialSkipText.text = " ";
                LoadGame();
            }
        }
    }

    private IEnumerator TutorialText()
    {
        tutorialSkipText.text = " Press X to Skip Tutorial";
        tutorialText.text = " Welcome! ";

        yield return new WaitForSeconds(5f);

        playerObject.SetActive(true);
        playerText.SetActive(true);
        tutorialText.text = " You are this circle! ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " When the game starts, you may press A or D, or left arrow and right arrow, to move right and left! ";
        yield return new WaitForSeconds(5f);

        shape1.SetActive(true);
        shape2.SetActive(true);
        shape3.SetActive(true);
        tutorialText.text = " When you move, your circle will be on a new shape. ";
        yield return new WaitForSeconds(5f);

        simonObject.SetActive(true);
        simonText.SetActive(true);
        tutorialText.text = " This is Simón. ";
        yield return new WaitForSeconds(5f);

        shape4.SetActive(true);
        shape5.SetActive(true);
        shape6.SetActive(true);
        tutorialText.text = " On Simón's turn, he will move randomly between his own shapes. ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " When Simón finishes moving, it will be your turn to move. ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " On your turn, must copy Simón's movements exactly. ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " If you do not, Simón will brutally murder your circle. ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " You will not be able to move when it is Simón's turn. ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " This is because Simón is a demigod. ";
        yield return new WaitForSeconds(5f);

        scoreText.SetActive(true);
        tutorialText.text = " In the top left is your level counter. ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " For each round you successfuly copy Simón, you will go up a level. ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " The higher the level, the more Simón will move. ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " If you beat Level 7, you win. ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " This is because Simón will grow tired of you, and will instead harass a different mortal. ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " Are you ready? ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " Begin! ";
        yield return new WaitForSeconds(5f);

        LoadGame();
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
