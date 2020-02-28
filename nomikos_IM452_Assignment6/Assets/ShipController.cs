using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    //enum ModeSwitching { Start, Acceleration }
    public Rigidbody2D ship;
    public float force = 0f;
    public float rotationAngle = 0f;

    public GameObject bullet;
    public float bulletSpeed = 10f;

    public float fireRate;
    float lastShot;

    //public AudioClip shootSound;

    // Update is called once per frame
    void Update()
    {
        //Basic Ship Controls
        if (Input.GetKey(KeyCode.W))
        {
            ship.AddForce(transform.right * force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ship.AddForce(-transform.right * force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationAngle);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //ShootBullet();
        }

        //Ship wraps if it moves off of the map
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
        else if (transform.position.y > 18.3f)
        {
            gameObject.transform.position = new Vector2(transform.position.x, (-transform.position.y));
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 0.25f);

        }
        else if (transform.position.y < -18.3f)
        {
            gameObject.transform.position = new Vector2(transform.position.x, (-transform.position.y));
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

        }
    }

    //Shoots a bullet
    void ShootBullet()
    {
        //Limits fire rate of bullets
        if (Time.time > fireRate + lastShot)
        {
            var bulletClone = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            Vector2 direction = transform.up;
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            lastShot = Time.time;

            //AudioSource.PlayClipAtPoint(shootSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        }

    }
}
