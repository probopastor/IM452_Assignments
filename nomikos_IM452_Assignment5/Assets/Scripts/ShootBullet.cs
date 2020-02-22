/*
* William Nomikos
* ShootBullet.cs
* Assignment 5
* Shoots doughnut projectiles from the player towards enemies. Also handles
* shooting sound effect.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public AudioSource soundEffectSource;
    public AudioClip shootingSound;

    public GameObject bullet;
    public float shootCooldown = 1f;
    public float bulletSpeed = 0f;

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                soundEffectSource.clip = shootingSound;
                soundEffectSource.Play();

                GameObject bulletClone = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
                bulletClone.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            }
    }
}
