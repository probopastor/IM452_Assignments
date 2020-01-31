/*
* William Nomikos
* PlayerBehavior.cs
* Assignment 2
* Script handles player input and movement, allowing the player to walk and jump via velocity manipulation.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D playerRb;

    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float jumpHeight = 0f;

    private float movePlayer = 0f;

    private bool canJump;

    private Transform playerTransform;

    private float xScale = 0f;
    private float yScale = 0f;
    private float zScale = 0f;


    // Start is called before the first frame update
    void Start()
    {
        xScale = transform.localScale.x;
        yScale = transform.localScale.y;
        zScale = transform.localScale.z;
        
        playerTransform = GetComponent<Transform>();
        canJump = true;
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if((playerTransform.localScale.x > xScale) || playerTransform.localScale.y > yScale || playerTransform.localScale.z > zScale)
        {
            playerTransform.localScale = new Vector3(xScale, yScale, zScale);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlayer = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpHeight);
            canJump = false;
        }
        playerRb.velocity = new Vector2(moveSpeed * movePlayer, playerRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
            this.transform.parent = collision.transform;
        }
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("KillZone"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
