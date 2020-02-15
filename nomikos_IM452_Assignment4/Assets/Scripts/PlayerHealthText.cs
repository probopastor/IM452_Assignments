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
        maxHealth = PlayerMeteor.currentPlayerHealth;
        playerHealthText.text = "Health: " + PlayerMeteor.currentPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Health: " + PlayerMeteor.currentPlayerHealth;
    }
}
