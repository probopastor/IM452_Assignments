/*
* William Nomikos
* HealthUI.cs
* Assignment 3
* Script changes UI health text to match the player's current health held in PlayerMovement.cs.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text thisText;

    // Update is called once per frame
    void Update()
    {
        thisText.text = "Health : " + PlayerMovement.currentPlayerHealth;
    }
}
