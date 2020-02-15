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
