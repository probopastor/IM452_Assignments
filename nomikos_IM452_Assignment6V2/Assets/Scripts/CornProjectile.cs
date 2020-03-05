/*
* William Nomikos
* CornProjectile.cs
* Assignment 6
* Script handles the Corn projectile's (a concrete product from the SmallProjectileCreator concrete creator) 
* behaviors after it is created via the factory.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornProjectile : Projectiles
{
    private AudioSource SoundEffectSource;
    private AudioClip splatSound;

    public CornProjectile()
    {
        this.projectileSpeed = 30f;
        this.damageOutput = 3.5f;

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
