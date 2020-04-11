/*
* William Nomikos
* PlayerMovement.cs
* Assignment 10
* Handles the player's behavior, including movement, health, lose status and win status. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public int playerHealth = 5;
    private int currentPlayerHealth = 0;
    public Text healthText;
    public Text headBopText;

    public GameObject losePanel;
    public GameObject winPanel;

    public float speed = 12f;
    public float jumpHeight = 1f;

    public float gravity = -9.81f;

    private Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject spawnCube;

    public int scoreToWin = 3;
    private int currentScore = 0;

    private bool isGrounded;
    private GameObject player;

    private PauseManager pauseManager;

    private void Start()
    {
        player = this.gameObject;
        pauseManager = FindObjectOfType<PauseManager>();
        losePanel.SetActive(false);
        winPanel.SetActive(false);

        currentPlayerHealth = playerHealth;

        currentScore = 0;
        PlacePlayerOnSpawnCube();

        healthText.text = "Health: " + currentPlayerHealth;
        headBopText.text = "Head Bops: " + currentScore + " / " + scoreToWin;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        healthText.text = "Health: " + currentPlayerHealth;
        headBopText.text = "Head Bops: " + currentScore + " / " + scoreToWin;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = gravity;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(velocity * Time.deltaTime);

    }

    public void DecreaseHealth(int damageTaken)
    {
        currentPlayerHealth -= damageTaken;

        if (currentPlayerHealth <= 0)
        {
            currentPlayerHealth = playerHealth;

            LoseGame();
        }
    }

    private void PlacePlayerOnSpawnCube()
    {
        controller.enabled = false;
        gameObject.transform.position = spawnCube.transform.position;
        controller.enabled = true;
    }

    private void LoseGame()
    {
        pauseManager.gameLost = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        losePanel.SetActive(true);
        Time.timeScale = 0;        
    }

    private void WinGame()
    {
        pauseManager.gameLost = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void IncreaseScore()
    {
        currentScore++;

        if(currentScore >= scoreToWin)
        {
            WinGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FrogWeakSpot"))
        {
            IncreaseScore();
            PlacePlayerOnSpawnCube();
        }
        else if(other.CompareTag("Projectile"))
        {
            DecreaseHealth(2);
        }
    }
}
