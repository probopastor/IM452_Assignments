using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    //enum ModeSwitching { Start, Acceleration }
    public Rigidbody2D ship;
    public float force = 0f;
    public float rotationAngle = 0f;

    public float playerHealth = 5f;
    private float currentPlayerHealth;

    //public AudioClip shootSound;

    private void Start()
    {
        currentPlayerHealth = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
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
        currentPlayerHealth -= healthAmount;

        LoseCheck();
    }

    private void LoseCheck()
    {
        if(currentPlayerHealth <= 0)
        {
            //Lose Game
        }
    }
}
