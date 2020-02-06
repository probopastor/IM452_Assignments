/*
* William Nomikos
* TimeUntilBehaviorSwitch.cs
* Assignment 3
* Script updates UI text to display the amount of time
* left before the player can change Phantom's behavior.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUntilBehaviorSwitch : MonoBehaviour
{
    public Text thisText;

    public static float timeRemaining = 0f;

    // Update is called once per frame
    void Update()
    {
        thisText.text = "Ability Cooldown Time: " + timeRemaining;
    }
}
