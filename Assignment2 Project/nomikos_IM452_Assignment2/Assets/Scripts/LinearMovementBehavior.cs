using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementBehavior : MonoBehaviour, IMovementType
{
    public float xDirection = 0f;
    public float yDirection = 0f;


    public void MovePattern()
    {
        StartCoroutine("MovePlatform");
    }

    private IEnumerator MovePlatform()
    {
        transform.position = new Vector2(transform.position.x + xDirection, transform.position.y + yDirection);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("MovePlatform");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PositionSwitchCircle"))
        {
            if(xDirection != 0)
            {
                xDirection *= -1;
            }

            if(yDirection != 0)
            {
                yDirection *= -1;
            }
        }
    }
}
