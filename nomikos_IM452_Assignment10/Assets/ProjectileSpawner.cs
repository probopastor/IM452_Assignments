using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

    void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Sphere", new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
