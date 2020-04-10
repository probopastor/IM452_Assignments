using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public int playerHealth = 1;
    public static int currentPlayerHealth = 0;
    //public Text healthText;

    //public GameObject losePanel;

    public float speed = 12f;
    public float jumpHeight = 1f;

    public float gravity = -9.81f;

    private Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject spawnCube;

    private bool isGrounded;
    private GameObject player;

    private void Start()
    {
        player = this.gameObject;
        //losePanel.SetActive(false);
        currentPlayerHealth = playerHealth;
        PlacePlayerOnSpawnCube();

        //healthText.text = "Health: " + currentPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //healthText.text = "Health: " + currentPlayerHealth;

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

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //losePanel.SetActive(true);

            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                //SceneManager.LoadScene("MainMenu");
            }
        }
    }

    private void PlacePlayerOnSpawnCube()
    {
        gameObject.transform.position = spawnCube.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yes");

        if(other.CompareTag("FrogWeakSpot"))
        {
            PlacePlayerOnSpawnCube();
        }
    }
}
