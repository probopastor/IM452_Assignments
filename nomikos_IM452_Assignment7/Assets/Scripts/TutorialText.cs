/*
* William Nomikos
* TutorialText.cs
* Assignment 7
* Handles in-game tutorial text upon first playing the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    public Text tutorialText;
    public Text timeUntilTeleportText;
    public GameObject timeUntilTeleportIcon;

    public GameObject ControllerIcon;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilTeleportText.enabled = false;
        timeUntilTeleportIcon.SetActive(false);
        ControllerIcon.SetActive(false);

        StartCoroutine("Tutorial");
    }

    private IEnumerator Tutorial()
    {
        tutorialText.text = "Welcome, you are the great Tornado! ";
        yield return new WaitForSeconds(3f);
        tutorialText.text = "Your goal is to suck up all of humanity! ";
        yield return new WaitForSeconds(3f);
        tutorialText.text = "As time progresses, the world around you will grow and develop. It may become too large for you to suck up. ";
        yield return new WaitForSeconds(4f);
        tutorialText.text = "Luckily, you have the profound ability to travel back in time! ";
        yield return new WaitForSeconds(4f);
        tutorialText.text = "Up at the top of the screen is your Time Travel Status. When it is set to True, press T to travel back! ";
        timeUntilTeleportText.enabled = true;
        timeUntilTeleportIcon.SetActive(true);
        yield return new WaitForSeconds(4f);

        tutorialText.text = "If the objects you are trying to suck up become too big, simply travel back in time to before life developed that much! ";
        yield return new WaitForSeconds(4f);

        tutorialText.text = "Here are you controls.";
        ControllerIcon.SetActive(true);
        yield return new WaitForSeconds(3f);

        tutorialText.text = "You win when you destroy everything in the future! ";
        yield return new WaitForSeconds(3f);
        tutorialText.text = "Good luck. ";
        yield return new WaitForSeconds(1f);
        tutorialText.enabled = false;
        yield return new WaitForSeconds(1f);
    }
}
