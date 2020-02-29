/*
* William Nomikos
* LargeProjectileCreator.cs
* Assignment 6
* A concrete creator, handles the creation of large projectiles 
* to be launched by the player, including Coconuts and Melons.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeProjectileCreator : ProjectileCreator
{
    private GameObject largeProjectile;

    public override GameObject CreateProjectilePrefab(string projectileType)
    {
        if(projectileType.Equals("Melon"))
        {
            largeProjectile = Resources.Load<GameObject>("MelonPrefab");
        }
        else if(projectileType.Equals("Coconut"))
        {
            largeProjectile = Resources.Load<GameObject>("CoconutPrefab");
        }

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
