/*
* William Nomikos
* WinCondition.cs
* Assignment 3
* Script handles the amount of Phantoms that must be killed in order
* for the player to win. Also handles win state activation.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public int EnemiesToWin = 1;

    public GameObject WinPanel;

    public static int EnemiesRemaining;
    public static int WinState;

    // Start is called before the first frame update
    void Start()
    {
        WinPanel.SetActive(false);
        WinState = EnemiesToWin;
        EnemiesRemaining = WinState;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemiesRemaining <= 0)
        {
            EnemiesRemaining = 0;
            WinPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
