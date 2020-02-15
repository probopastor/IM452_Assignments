/*
* William Nomikos
* SmallMissile.cs
* Assignment 4
* Subclass of Missile that handles the speed, damage and size parameters
* of the small missile varient.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMissile : Missile
{
    public float damage = 1;
    public float smallMissileSpeed = 1f;
    public float smallMissileSize = 1f;

    private void Awake()
    {
        missileSize = smallMissileSize;
        missileSpeed = smallMissileSpeed;
        damageOutput = damage;
    }
}
