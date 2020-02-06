/*
* William Nomikos
* PhantomsRemaining.cs
* Assignment 3
* Script updates UI text to display how many more phantoms the player 
* must kill to win.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhantomsRemaining : MonoBehaviour
{
    public Text thisText;

    // Update is called once per frame
    void Update()
    {
        thisText.text = "Enemies Remaining " + WinCondition.EnemiesRemaining + " / " + WinCondition.WinState;
    }
}
