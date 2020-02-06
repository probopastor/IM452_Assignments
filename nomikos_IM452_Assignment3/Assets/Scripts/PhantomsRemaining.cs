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
