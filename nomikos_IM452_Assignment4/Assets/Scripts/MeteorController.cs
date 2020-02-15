using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeteorController : MonoBehaviour
{
    protected Vector3 startingSize;
    protected float playerSpeed = 0f;

    private void Start()
    {
        startingSize = transform.localScale;
        SetPlayerSize(startingSize);
    }

    protected Vector3 GetPlayerSize()
    {
        return transform.localScale;
    }

    protected float GetPlayerSpeed()
    {
        return playerSpeed;
    }

    protected void SetPlayerSize(Vector3 newSize)
    {
        transform.localScale = newSize;
    }

    protected void SetPlayerSpeed(float speed)
    {
        playerSpeed = speed;
    }

    public virtual void AddSpeed()
    {
        playerSpeed++;
    }
    public virtual void AddSize()
    {
        transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y + 1, 1);
    }
}
