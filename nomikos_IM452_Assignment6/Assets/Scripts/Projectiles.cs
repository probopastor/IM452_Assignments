/*
* William Nomikos
* Projectiles.cs
* Assignment 6
* Handles main projectile behavior after a projectile is created
* by the factory. This is the product that is produced.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float projectileSpeed = 1f;

    public float damageOutput = 1f;

    public void ProjectileMovement(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
