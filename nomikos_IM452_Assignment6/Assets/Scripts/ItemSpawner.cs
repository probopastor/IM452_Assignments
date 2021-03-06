﻿/*
* William Nomikos
* ItemSpawner.cs
* Assignment 6
* Script spawns in item pickups at certain periods of time at Item Spawner objects in scene.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemsToSpawn;
    public int timeBetweenSpawns = 1;
    public int timeBeforeFirstSpawn = 1;
    private int i = 0;
    public bool doOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        doOnce = false;
        i = 0;
        StartCoroutine("SpawnItems");
    }

    private IEnumerator SpawnItems()
    {
        if (!doOnce)
        {
            yield return new WaitForSeconds(timeBeforeFirstSpawn);
            doOnce = true;
        }

        if (itemsToSpawn[i] != null)
        {
            GameObject enemyClone = Instantiate(itemsToSpawn[i], gameObject.transform.position, Quaternion.identity);
        }

        i++;

        if (i >= itemsToSpawn.Length)
        {
            i = 0;
        }

        if (doOnce)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

        StartCoroutine("SpawnItems");
    }
}
