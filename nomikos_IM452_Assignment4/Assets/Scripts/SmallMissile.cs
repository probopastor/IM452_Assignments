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
