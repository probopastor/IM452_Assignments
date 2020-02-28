﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallProjectileCreator : ProjectileCreator
{
    public GameObject cornProjectile;
    public GameObject peaProjectile;

    private GameObject smallProjectile;

    // Start is called before the first frame update
    void Start()
    {
        //CreateProjectilePrefab("Corn");
        //CreateProjectilePrefab("Pea");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override GameObject CreateProjectilePrefab(string projectileType)
    {
        if(projectileType.Equals("Corn"))
        {
            //smallProjectile = cornProjectile;
            smallProjectile = Resources.Load<GameObject>("CornPrefab");
        }
        else if(projectileType.Equals("Strawberry"))
        {
            //smallProjectile = peaProjectile;
            smallProjectile = Resources.Load<GameObject>("StrawberryPrefab");
        }

        Debug.Log("Projectile created: " + smallProjectile.name);
        return smallProjectile;
    }

    public override void AddProjectileScript(GameObject thisObjectPrefab, string projectileType)
    {
        if(projectileType.Equals("Corn"))
        {
            if(thisObjectPrefab.GetComponent<CornProjectile>() == null)
            {
                thisObjectPrefab.AddComponent<CornProjectile>();
            }
        }
        else if(projectileType.Equals("Strawberry"))
        {
            if (thisObjectPrefab.GetComponent<StrawberryProjectile>() == null)
            {
                thisObjectPrefab.AddComponent<StrawberryProjectile>();
            }
        }
    }
}
