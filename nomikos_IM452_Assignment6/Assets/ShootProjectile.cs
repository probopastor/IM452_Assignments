﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public float xProjectileMod = 0f;
    public float yProjectileMod = 0f;
    public float zProjectileMod = 0f;

    public ProjectileCreator projectileCreator;

    public float startAmmunition = 50f;
    private float currentAmmunition;

    private string projectileType;

    private bool isCorn;
    private bool isPea;
    private bool isMelon;
    private bool isCoconut;

    private bool smallCreatorSet;
    private bool largeCreatorSet;

    public GameObject bullet;
    public float bulletSpeed = 10f;

    public float fireRate;
    float lastShot;

    //public AudioClip shootSound;

    private void Start()
    {
        projectileType = "Corn";
        projectileCreator = new SmallProjectileCreator();
        smallCreatorSet = true;
        largeCreatorSet = false;
        currentAmmunition = startAmmunition;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeGunType();

        if ((isCorn || isPea) && !smallCreatorSet)
        {
            projectileCreator = new SmallProjectileCreator();
            smallCreatorSet = true;
            largeCreatorSet = false;
        }
        else if ((isMelon || isCoconut) && !largeCreatorSet)
        {
            projectileCreator = new LargeProjectileCreator();
            largeCreatorSet = true;
            smallCreatorSet = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ShootBullet(projectileType);
        }

    }

    private void ChangeGunType()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            projectileType = "Corn";
            isCorn = true;
            isPea = false;
            isMelon = false;
            isCoconut = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            projectileType = "Pea";
            isCorn = false;
            isPea = true;
            isMelon = false;
            isCoconut = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            projectileType = "Melon";
            isCorn = false;
            isPea = false;
            isMelon = true;
            isCoconut = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            projectileType = "Coconut";
            isCorn = false;
            isPea = false;
            isMelon = false;
            isCoconut = true;
        }
    }

    //Shoots a bullet
    void ShootBullet(string projectileType)
    {
        //Limits fire rate of bullets
        //if (Time.time > fireRate + lastShot)
        //{
        //    var bulletClone = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
        //    Vector2 direction = transform.up;
        //    bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        //    lastShot = Time.time;

        //    //AudioSource.PlayClipAtPoint(shootSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        //}



        if (currentAmmunition > 0)
        {
            if (Time.time > fireRate + lastShot)
            {
                GameObject projectile = null;

                projectile = projectileCreator.CreateProjectilePrefab(projectileType);

                var projectileClone = (GameObject)Instantiate(projectile, new Vector3(transform.position.x + xProjectileMod, transform.position.y + yProjectileMod, transform.position.z + zProjectileMod), transform.rotation);

                projectileCreator.AddProjectileScript(projectileClone, projectileType);

                Vector2 direction = transform.right;

                projectileClone.GetComponent<Projectiles>().ProjectileMovement(direction);

                lastShot = Time.time;

                //AudioSource.PlayClipAtPoint(shootSound, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
            }
        }

    }
}
