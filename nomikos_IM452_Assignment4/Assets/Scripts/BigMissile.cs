using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMissile : Missile
{
    public float damage = 1;
    public float bigMissileSpeed = 1f;
    public float bigMissileSize = 1f;

    private void Start()
    {
        SetDamage();
        SetSize();
        SetSpeed();
    }

    public override void SetDamage()
    {
        damageOutput = damage;
    }

    public override void SetSize()
    {
        ChangeMissileScale(new Vector3(bigMissileSize, bigMissileSize));
    }

    public override void SetSpeed()
    {
        missileSpeed = bigMissileSpeed;
    }
}
