﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeProjectileCreator : ProjectileCreator
{
    public GameObject melonProjectile;
    public GameObject coconutProjectile;

    private GameObject largeProjectile;
    // Start is called before the first frame update
    void Start()
    {
        CreateProjectilePrefab("Melon");
        CreateProjectilePrefab("Coconut");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override GameObject CreateProjectilePrefab(string projectileType)
    {
        if(projectileType.Equals("Melon"))
        {
            //largeProjectile = melonProjectile;
            largeProjectile = Resources.Load<GameObject>("MelonPrefab");
        }
        else if(projectileType.Equals("Coconut"))
        {
            //largeProjectile = coconutProjectile;
            largeProjectile = Resources.Load<GameObject>("CoconutPrefab");
        }

        Debug.Log("Projectile created: " + largeProjectile.name);
        return largeProjectile;
    }

    public override void AddProjectileScript(GameObject thisObjectPrefab, string projectileType)
    {
        if (projectileType.Equals("Melon"))
        {
            if(thisObjectPrefab.GetComponent<MelonProjectile>() == null)
            {
                thisObjectPrefab.AddComponent<MelonProjectile>();
            }
        }
        else if (projectileType.Equals("Coconut"))
        {
            if (thisObjectPrefab.GetComponent<CoconutProjectile>() == null)
            {
                thisObjectPrefab.AddComponent<CoconutProjectile>();
            }
        }
    }
}