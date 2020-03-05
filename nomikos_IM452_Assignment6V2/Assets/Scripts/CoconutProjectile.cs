/*
* William Nomikos
* CoconutProjectile.cs
* Assignment 6
* Script handles the Coconut projectile's (a concrete product from the LargeProjectileCreator concrete creator) 
* behaviors after it is created via the factory.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutProjectile : Projectiles
{
    private AudioSource SoundEffectSource;
    private AudioClip splatSound;

    public CoconutProjectile()
    {
        this.projectileSpeed = 6f;
        this.damageOutput = 7.5f;
    }
    private void Awake()
    {
        SoundEffectSource = GameObject.FindWithTag("Canvas").GetComponent<AudioSource>();
        splatSound = Resources.Load<AudioClip>("SplatSound");
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x < -32.4f) || (transform.position.x > 32.4f) || (transform.position.y > 18.47f) || (transform.position.y < -13.71f))
        {
            DestroyProjectile(false);
        }
    }

    public void DestroyProjectile(bool useSound)
    {
        if (useSound)
        {
            SoundEffectSource.clip = splatSound;
            SoundEffectSource.Play();
        }

        Destroy(this.gameObject);
    }
}
