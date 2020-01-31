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

    private void Update()
    {
        if (!doOnce)
        {
            doOnce = true;
            MovePattern();
        }
    }

    public void MovePattern()
    {
        timeRemaining = timeInDirection;
        StartCoroutine("MovePlatformRight");
    }

    private IEnumerator MovePlatformRight()
    {
        if(timeRemaining > 0)
        {
            transform.position = new Vector2(transform.position.x + xDirection * Time.deltaTime, transform.position.y - yDirection * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
            timeRemaining -= 0.01f;
            StartCoroutine("MovePlatformRight");

        }
        else if(timeRemaining <= 0)
        {
            yield return new WaitForSeconds(0.01f);
            timeRemaining = timeInDirection;
            StartCoroutine("MovePlatformLeft");
        }
    }

    private IEnumerator MovePlatformLeft()
    {
        if (timeRemaining > 0)
        {
            transform.position = new Vector2(transform.position.x - xDirection * Time.deltaTime, transform.position.y - yDirection * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
            timeRemaining -= 0.01f;
            StartCoroutine("MovePlatformLeft");
        }
        else if (timeRemaining <= 0)
        {
            yield return new WaitForSeconds(0.01f);
            timeRemaining = timeInDirection;
            StartCoroutine("MovePlatformRight");
        }
    }

}
