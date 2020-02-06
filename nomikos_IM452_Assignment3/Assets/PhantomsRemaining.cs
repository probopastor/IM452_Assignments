using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhantomsRemaining : MonoBehaviour
{
    public Text thisText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisText.text = "Enemies Remaining " + WinCondition.EnemiesRemaining + " / " + WinCondition.WinState;
    }
}
