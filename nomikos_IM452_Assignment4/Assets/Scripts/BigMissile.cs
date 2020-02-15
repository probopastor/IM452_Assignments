/*
* William Nomikos
* BigMissile.cs
* Assignment 4
* Concrete Missile Class handles the parameters for large missile varients,
* including size, speed and damage.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMissile : Missile
{
    public float damage = 1;
    public float bigMissileSpeed = 1f;
    public float bigMissileSize = 1f;

    private void Awake()
    {
        missileSize = bigMissileSize;
        missileSpeed = bigMissileSpeed;
        damageOutput = damage;
    }
}
