using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int currentHealth = 10;
    private int swordPowerNumber = 1;
    public int swordDamageAmount = 3;
    public int swordBurnDamageAmount = 1;
    public int swordStunDamageAmount = 2;
    public SpriteRenderer swordRend;
    public Color[] swordColors;
    // Start is called before the first frame update
    void Start()
    {
        swordRend.color = swordColors[0];
        swordPowerNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        CheckSwordPower();

        Debug.Log("Sword power number " + GetSwordPowerNumber());

        //Rotation of player towards mouse pos taken from https://answers.unity.com/questions/855976/make-a-player-model-rotate-towards-mouse-location.html
        //From user BenZed
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
    }

    //Rotation of player towards mouse pos taken from https://answers.unity.com/questions/855976/make-a-player-model-rotate-towards-mouse-location.html
    //From user BenZed
    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
    }

    private void CheckHealth()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("Game Over");
            LoseGame();
        }
    }

    private void LoseGame()
    {
        //Lose Game Here
    }

    private void CheckSwordPower()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            swordPowerNumber = 1;
            swordRend.color = swordColors[0];
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            swordPowerNumber = 2;
            swordRend.color = swordColors[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            swordPowerNumber = 3;
            swordRend.color = swordColors[2];
        }
    }

    public int GetSwordPowerNumber()
    {
        return swordPowerNumber;
    }

    public int GetSwordDamageAmount()
    {
        return swordDamageAmount;
    }

    public int GetSwordBurnDamageAmount()
    {
        return swordBurnDamageAmount;
    }

    public int GetSwordStunDamageAmount()
    {
        return swordStunDamageAmount;
    }
}
