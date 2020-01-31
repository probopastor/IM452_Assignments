using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D playerRb;

    [SerializeField] private float moveSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movePlayer = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector2(moveSpeed * movePlayer, playerRb.velocity.y);
    }
}
