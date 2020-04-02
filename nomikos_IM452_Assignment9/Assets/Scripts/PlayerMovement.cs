/*
* William Nomikos
* PlayerMovement.cs
* Assignment 9
* Handles linear movement for the player.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
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
}
