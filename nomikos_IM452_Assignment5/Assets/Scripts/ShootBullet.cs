/*
* William Nomikos
* ShootBullet.cs
* Assignment 3
* Script handles bullet instantiation, shooting sound effects, and
* shooting cooldown.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    //public AudioSource soundEffectSource;
    //public AudioClip shootingSound;

    public GameObject bullet;
    public float shootCooldown = 1f;
    public float bulletSpeed = 0f;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //soundEffectSource.clip = shootingSound;
                //soundEffectSource.Play();

                GameObject bulletClone = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
                bulletClone.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            }
    }
}
