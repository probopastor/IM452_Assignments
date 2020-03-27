using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isDimension1;
    private float gravityDimension1 = 1f;
    private float gravityDimension2 = 1f;
    private bool canJump;

    public float jumpHeight = 1f;
    public float playerSpeed = 1f;

    public int coinsToWin = 5;
    private int coinsOwned = 0;

    private PauseManager pauseManager;

    public GameObject winPanel;

    private bool gameWon = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        pauseManager = FindObjectOfType<PauseManager>();
        winPanel.SetActive(false);
        gameWon = false;
        isDimension1 = true;
        gravityDimension1 = rb.gravityScale;
        gravityDimension2 = -rb.gravityScale;

        canJump = true;
        coinsOwned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(coinsOwned >= coinsToWin)
        {
            WinGame();
        }

        if(!pauseManager.paused && !gameWon)
        {
            PlayerMovement();
        }

        ClampPlayerPos();
    }

    private void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isDimension1)
            {
                isDimension1 = false;
            }
            else if (!isDimension1)
            {
                isDimension1 = true;
            }

            CheckDimension();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                //rb.AddForce(Vector2.up * jumpHeight);
                rb.velocity = Vector2.up * jumpHeight;
                canJump = false;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * playerSpeed, Space.World);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * Time.deltaTime * playerSpeed, Space.World);
        }
    }

    private void ClampPlayerPos()
    {
        Vector3 playerPos = Camera.main.WorldToViewportPoint(transform.position);
        playerPos.x = Mathf.Clamp01(playerPos.x);
        playerPos.y = Mathf.Clamp01(playerPos.y);
        transform.position = Camera.main.ViewportToWorldPoint(playerPos);
    }

    private void CheckDimension()
    {
        if (isDimension1)
        {
            rb.gravityScale = gravityDimension1;
        }           
        else if(!isDimension1)
        {
            rb.gravityScale = gravityDimension2;
        }

        gameObject.transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        jumpHeight = -jumpHeight;
    }

    private void WinGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameWon = true;
        winPanel.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            coinsOwned++;
            Destroy(collision.gameObject);
        }
    }
}
