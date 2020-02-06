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

    private float currentShootCooldown = 0f;


    private void Start()
    {
        currentShootCooldown = shootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentShootCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                soundEffectSource.clip = shootingSound;
                soundEffectSource.Play();

                GameObject bulletClone = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
                bulletClone.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            }
        }
        else
        {
            currentShootCooldown--;
        }
    }
}
