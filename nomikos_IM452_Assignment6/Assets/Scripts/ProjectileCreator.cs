using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileCreator : MonoBehaviour
{
    public abstract GameObject CreateProjectilePrefab(string projectileType);
    public abstract void AddProjectileScript(GameObject thisObjectPrefab, string projectileType);
}
