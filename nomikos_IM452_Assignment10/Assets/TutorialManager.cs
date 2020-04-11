using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public Text tutorialText;
    public Text tutorialSkipText;
    public string sceneToLoad;

    public GameObject healthObj;
    public GameObject frogBops;
    public GameObject controlPanel;

    private IEnumerator coroutine;
    private bool doOnce;

    void Start()
    {
        healthObj.SetActive(false);
        frogBops.SetActive(false);
        controlPanel.SetActive(false);

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

        tutorialText.text = " In this game, you must defeat an evil frog! ";
        yield return new WaitForSeconds(5f);

        controlPanel.SetActive(true);
        tutorialText.text = " Use WASD to move your player, the cylander! ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " Press Space to Jump ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " Soon, a massive evil frog will spawn. It will shoot evil balls of evil at you... ";
        yield return new WaitForSeconds(5f);

        healthObj.SetActive(true);
        tutorialText.text = " If one of its projectiles hits you, you will take 2 damage! ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " If your health hits 0, you will die. ";
        yield return new WaitForSeconds(5f);

        frogBops.SetActive(true);
        tutorialText.text = " To defeat the frog, you must jump on its head 3 times! ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " When you jump on its head, you will be teleported back to the purple square! ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " Are you ready to fight the Evil frog? ";
        yield return new WaitForSeconds(5f);

        tutorialText.text = " Go! ";
        yield return new WaitForSeconds(5f);

        LoadGame();
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
