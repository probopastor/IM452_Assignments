using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementBehavior : MonoBehaviour, IMovementType
{
    public float xDirection = 0f;
    public float yDirection = 0f;

    public float timeInDirection = 0f;
    public float timeRemaining = 0f;

    bool doOnce;
    bool moveRight;
    bool moveLeft;

    private void Update()
    {
        MovePattern();
    }

    public void MovePattern()
    {
        if(!doOnce)
        {
            moveRight = true;
            moveLeft = false;
            timeRemaining = timeInDirection;
            doOnce = true;
        }


        if(moveRight)
        {
            if (timeRemaining > 0)
            {
                transform.position = new Vector2(transform.position.x + xDirection * Time.deltaTime, transform.position.y - yDirection * Time.deltaTime);
                timeRemaining -= 0.01f;
            }
            else if (timeRemaining <= 0)
            {
                timeRemaining = timeInDirection;
                moveRight = false;
                moveLeft = true;
            }
        }
        else if(moveLeft)
        {
            if (timeRemaining > 0)
            {
                transform.position = new Vector2(transform.position.x - xDirection * Time.deltaTime, transform.position.y - yDirection * Time.deltaTime);
                timeRemaining -= 0.01f;
            }
            else if (timeRemaining <= 0)
            {
                timeRemaining = timeInDirection;
                moveRight = true;
                moveLeft = false;
            }
        }

    }
}
