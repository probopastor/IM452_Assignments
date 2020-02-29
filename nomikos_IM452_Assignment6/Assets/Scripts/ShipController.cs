using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public AudioSource SoundEffectSource;
    public AudioClip pickUpHealthSound;
    public AudioClip damageSound;

    public Text healthText;
    public Text enemiesDefeatedText;

    public GameObject losePanel;
    public GameObject winPanel;

    public int enemiesToWin = 25;

    public int enemiesDefeated = 0;

    public Rigidbody2D ship;
    public float force = 0f;
    public float rotationAngle = 0f;

    public float playerHealth = 5f;
    private float currentPlayerHealth;

    //public AudioClip shootSound;

    private void Start()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(false);

        currentPlayerHealth = playerHealth;
        enemiesDefeated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + currentPlayerHealth;
        enemiesDefeatedText.text = "Enemies Defeated: " + enemiesDefeated + " / " + 25;

        //Basic Ship Controls
        if (Input.GetKey(KeyCode.W))
        {
            ship.AddForce(transform.right * force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ship.AddForce(-transform.right * force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationAngle);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationAngle);
        }

        //Ship wraps if it moves off of the map
        if (transform.position.x < -32.4f)
        {
            gameObject.transform.position = new Vector2((-transform.position.x), transform.position.y);
            gameObject.transform.position = new Vector2(transform.position.x - 0.25f, transform.position.y);
        }
        else if (transform.position.x > 32.4f)
        {
            gameObject.transform.position = new Vector2((-transform.position.x), transform.position.y);
            gameObject.transform.position = new Vector2(transform.position.x + 0.25f, transform.position.y);
        }
        else if (transform.position.y > 18.47f)
        {
            gameObject.transform.position = new Vector2(transform.position.x, -13.69f);
        }
        else if (transform.position.y < -13.71f)
        {
            gameObject.transform.position = new Vector2(transform.position.x, 18.45f);
        }
    }

    public void DecreaseHealth(float healthAmount)
    {
        if(healthAmount < 0)
        {
            SoundEffectSource.clip = pickUpHealthSound;
            SoundEffectSource.Play();
        }
        else if(healthAmount > 0)
        {
            SoundEffectSource.clip = damageSound;
            SoundEffectSource.Play();
        }
        currentPlayerHealth -= healthAmount;

        LoseCheck();
    }

    public void UpdateEnemiesDefeated()
    {
        enemiesDefeated++;
        if(enemiesDefeated >= enemiesToWin)
        {
            WinGame();
        }
    }

    private void LoseCheck()
    {
        if(currentPlayerHealth <= 0)
        {
            currentPlayerHealth = 0;
            losePanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
