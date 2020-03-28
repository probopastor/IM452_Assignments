/*
* William Nomikos
* MoveLeft.cs
* Assignment 8
* Moves gameobjects left across the screen, and destroys them when they
* are off the screen. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float movementSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -20.94)
        {
            Destroy(gameObject);
        }
    }
}
