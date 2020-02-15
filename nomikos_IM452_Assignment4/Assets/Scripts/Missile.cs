using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Missile : MonoBehaviour
{
    protected float missileSpeed = 1f;
    protected float damageOutput = 1f;
    protected float missileSize;

    private void Start()
    {
        Vector3 thisMissileSize = new Vector3(missileSize, missileSize, 1);
        transform.localScale = thisMissileSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-missileSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -22)
        {
            Destroy(gameObject, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            MeteorController.currentPlayerHealth -= damageOutput;

            Destroy(gameObject);
        }
    }

    protected Vector3 GetMissileSize()
    {
        return transform.localScale;
    }

    protected float GetSpeed()
    {
        return missileSpeed;
    }

    protected virtual void ChangeSize(Vector3 size)
    {
        transform.localScale = size;
    }

    protected virtual void ChangeSpeed(float speed)
    {
        missileSpeed = speed;
    }
}
