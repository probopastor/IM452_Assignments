using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject player;

    public float speed = 1f;
    public float health = 10f;
    public float damageOutput = 1f;
    public float maxVelocity = 20f;

    public bool isPontoon;

    public bool isYellow;
    public bool isPink;
    public bool isGreen;
    public bool isBrown;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        WarpOnMap();

        if(!isPontoon)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if(isPontoon)
        {
            Vector2 randomDirection = new Vector2(Random.Range(0, 360), Random.Range(0, 360)).normalized;
            gameObject.GetComponent<Rigidbody2D>().velocity = randomDirection;
        }
    }

    private void DecreaseHealth(float healthAmount)
    {
        health -= healthAmount;

        if(health <= 0)
        {
            player.GetComponent<ShipController>().UpdateEnemiesDefeated();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isYellow)
        {
            if (collision.CompareTag("Corn"))
            {
                DecreaseHealth(collision.GetComponent<CornProjectile>().damageOutput);
            }
        }
        else if(isPink)
        {
            if (collision.CompareTag("Strawberry"))
            {
                DecreaseHealth(collision.GetComponent<StrawberryProjectile>().damageOutput);
            }
        }
        else if(isGreen)
        {
            if (collision.CompareTag("Melon"))
            {
                DecreaseHealth(collision.GetComponent<MelonProjectile>().damageOutput);
            }
        }
        else if(isBrown)
        {
            if (collision.CompareTag("Coconut"))
            {
                DecreaseHealth(collision.GetComponent<CoconutProjectile>().damageOutput);
            }
        }
        
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<ShipController>().DecreaseHealth(damageOutput);
            Destroy(gameObject);
        }
    }

    private void WarpOnMap()
    {
        if (transform.position.x < -32.4f)
        {
            gameObject.transform.position = new Vector2((-transform.position.x), transform.position.y);
            gameObject.transform.position = new Vector2(transform.position.x - 0.25f, transform.position.y);
        }
        else if (transform.position.x > 32.4f)
        {
            gameObject.transform.position = new Vector2((-transform.position.x), transform.position.y);
            gameObject.transform.position = new Vector2(transform.position.x + 0.25f, transform.position.y);
        }
        else if (transform.position.y > 18.47f)
        {
            gameObject.transform.position = new Vector2(transform.position.x, -13.69f);
        }
        else if (transform.position.y < -13.71f)
        {
            gameObject.transform.position = new Vector2(transform.position.x, 18.45f);
        }
    }
}
