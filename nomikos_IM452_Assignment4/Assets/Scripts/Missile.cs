using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Missile : MonoBehaviour
{
    protected float missileSpeed = 1f;
    protected float damageOutput = 1f;
    protected Vector3 missileSize;

    private void Start()
    {
        missileSize = gameObject.transform.localScale;
        transform.localScale = missileSize;
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

    protected void ChangeMissileScale(Vector3 newScale)
    {
        missileSize = gameObject.transform.localScale;
        transform.localScale = newScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            MeteorController.currentPlayerHealth -= damageOutput;

            Destroy(gameObject);
        }
    }

    public abstract void SetDamage();
    public abstract void SetSize();
    public abstract void SetSpeed();


}
