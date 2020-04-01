using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int currentHealth = 10;
    private int swordPowerNumber = 1;
    public int swordDamageAmount = 3;
    public int swordBurnDamageAmount = 1;
    public int swordStunDamageAmount = 2;
    public SpriteRenderer swordRend;
    public Color[] swordColors;

    public Color defaultUIColor;
    public Color selectedUIColor;
    public Image[] swordBackgroundImages;

    public GameObject losePanel;
    private PauseManager pauseManager;
    
    // Start is called before the first frame update
    void Start()
    {
        losePanel.SetActive(false);
        pauseManager = FindObjectOfType<PauseManager>();
        swordRend.color = swordColors[0];
        swordPowerNumber = 1;
        UIImageSelectedColor();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        CheckSwordPower();

        Debug.Log("Sword power number " + GetSwordPowerNumber());

        if(!pauseManager.gameLost)
        {
            //Rotation of player towards mouse pos taken from https://answers.unity.com/questions/855976/make-a-player-model-rotate-towards-mouse-location.html
            //From user BenZed
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
        }
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
        pauseManager.gameLost = true;
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void CheckSwordPower()
    {
        if(!pauseManager.gameLost)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                swordPowerNumber = 1;
                swordRend.color = swordColors[0];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                swordPowerNumber = 2;
                swordRend.color = swordColors[1];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                swordPowerNumber = 3;
                swordRend.color = swordColors[2];
            }

            UIImageSelectedColor();
        }
    }

    private void UIImageSelectedColor()
    {
        if(swordPowerNumber == 1)
        {
            swordBackgroundImages[0].color = selectedUIColor;
            swordBackgroundImages[1].color = defaultUIColor;
            swordBackgroundImages[2].color = defaultUIColor;

        }
        else if(swordPowerNumber == 2)
        {
            swordBackgroundImages[0].color = defaultUIColor;
            swordBackgroundImages[1].color = selectedUIColor;
            swordBackgroundImages[2].color = defaultUIColor;
        }
        else if(swordPowerNumber == 3)
        {
            swordBackgroundImages[0].color = defaultUIColor;
            swordBackgroundImages[1].color = defaultUIColor;
            swordBackgroundImages[2].color = selectedUIColor;
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
