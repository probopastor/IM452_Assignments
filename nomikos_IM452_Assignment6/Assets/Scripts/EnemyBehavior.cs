/*
* William Nomikos
* EnemyBehavior.cs
* Assignment 6
* Handles enemy ship movement, damage, and sound effects. Also distinguishes between fruits to
* determine if ship should be damaged by the projectile or not.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private AudioSource SoundEffectSource;
    public AudioClip deflectionSound;

    private GameObject player;

    public float speed = 1f;
    public float health = 10f;
    public float damageOutput = 1f;
    public float maxVelocity = 360f;

    public bool isPontoon;

    public bool isYellow;
    public bool isPink;
    public bool isGreen;
    public bool isBrown;

    private bool doOnce;

    // Start is called before the first frame update
    void Start()
    {
        SoundEffectSource = GameObject.FindWithTag("Canvas").GetComponent<AudioSource>();
        deflectionSound = Resources.Load<AudioClip>("DeflectionSound");
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
        else if(isPontoon && !doOnce)
        {
            doOnce = true;
            Vector2 randomDirection = new Vector2(Random.Range(-maxVelocity, maxVelocity), Random.Range(-maxVelocity, maxVelocity)).normalized;
            gameObject.GetComponent<Rigidbody2D>().velocity = randomDirection * speed;
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
                collision.GetComponent<CornProjectile>().DestroyProjectile(true);
                DecreaseHealth(collision.GetComponent<CornProjectile>().damageOutput);
            }
            else
            {
                SoundEffectSource.clip = deflectionSound;
                SoundEffectSource.Play();
                Destroy(collision.GetComponent<GameObject>());
            }
        }
        else if(isPink)
        {
            if (collision.CompareTag("Strawberry"))
            {
                collision.GetComponent<StrawberryProjectile>().DestroyProjectile(true);
                DecreaseHealth(collision.GetComponent<StrawberryProjectile>().damageOutput);
            }
            else
            {
                SoundEffectSource.clip = deflectionSound;
                SoundEffectSource.Play();
                Destroy(collision.GetComponent<GameObject>());
            }
        }
        else if(isGreen)
        {
            if (collision.CompareTag("Melon"))
            {
                collision.GetComponent<MelonProjectile>().DestroyProjectile(true);
                DecreaseHealth(collision.GetComponent<MelonProjectile>().damageOutput);
            }
            else
            {
                SoundEffectSource.clip = deflectionSound;
                SoundEffectSource.Play();
                Destroy(collision.GetComponent<GameObject>());
            }
        }
        else if(isBrown)
        {
            if (collision.CompareTag("Coconut"))
            {
                collision.GetComponent<CoconutProjectile>().DestroyProjectile(true);
                DecreaseHealth(collision.GetComponent<CoconutProjectile>().damageOutput);
            }
            else
            {
                SoundEffectSource.clip = deflectionSound;
                SoundEffectSource.Play();
                Destroy(collision.GetComponent<GameObject>());
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
