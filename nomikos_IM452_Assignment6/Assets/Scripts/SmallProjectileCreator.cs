/*
* William Nomikos
* SmallProjectileCreator.cs
* Assignment 6
* A concrete creator, handles the creation of small projectiles 
* to be launched by the player, including Strawberries and Corn.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallProjectileCreator : ProjectileCreator
{
    private GameObject smallProjectile;

    public override GameObject CreateProjectilePrefab(string projectileType)
    {
        if(projectileType.Equals("Corn"))
        {
            smallProjectile = Resources.Load<GameObject>("CornPrefab");
        }
        else if(projectileType.Equals("Strawberry"))
        {
            smallProjectile = Resources.Load<GameObject>("StrawberryPrefab");
        }

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
