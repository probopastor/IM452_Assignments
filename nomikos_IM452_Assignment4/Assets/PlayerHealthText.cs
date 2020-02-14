using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthText : MonoBehaviour
{
    public Text playerHealthText;

    private float maxHealth = 0f;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = MeteorController.currentPlayerHealth;
        playerHealthText.text = "Health: " + MeteorController.currentPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Health: " + MeteorController.currentPlayerHealth;
    }
}
