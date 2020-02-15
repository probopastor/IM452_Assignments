using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeteor : MeteorController
{
    public float playerHealth = 5f;
    public static float currentPlayerHealth = 0f;

    public GameObject losePanel;

    public float movementSpeed = 1f;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerSpeed(movementSpeed);

        currentPlayerHealth = playerHealth;
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayerHealth <= 0)
        {
            StartCoroutine("LoseGame");
        }

        //Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * playerSpeed, Space.World);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.up * Time.deltaTime * playerSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * playerSpeed, Space.World);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * Time.deltaTime * playerSpeed, Space.World);
        }

        Vector3 playerPos = Camera.main.WorldToViewportPoint(transform.position);
        playerPos.x = Mathf.Clamp01(playerPos.x);
        playerPos.y = Mathf.Clamp01(playerPos.y);
        transform.position = Camera.main.ViewportToWorldPoint(playerPos);
    }

    private IEnumerator LoseGame()
    {
        losePanel.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        Time.timeScale = 0;
    }
}
