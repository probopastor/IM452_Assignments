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
