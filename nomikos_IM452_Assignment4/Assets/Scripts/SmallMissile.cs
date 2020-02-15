using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMissile : Missile
{
    public float damage = 1;
    public float smallMissileSpeed = 1f;
    public float smallMissileSize = 1f;

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
        ChangeMissileScale(new Vector3(smallMissileSize, smallMissileSize));
    }

    public override void SetSpeed()
    {
        missileSpeed = smallMissileSpeed;
    }
}
