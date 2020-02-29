using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    public int timeBetweenSpawns = 1;
    public int timeBeforeFirstSpawn = 1;
    private int i = 0;
    public bool doOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        doOnce = false;
        i = 0;
        StartCoroutine("SpawnEnemies");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        if(!doOnce)
        {
            yield return new WaitForSeconds(timeBeforeFirstSpawn);
            doOnce = true;
        }
        
        if(enemiesToSpawn[i] != null)
        {
            GameObject enemyClone = Instantiate(enemiesToSpawn[i], gameObject.transform.position, Quaternion.identity);
        }

        i++;

        if(i >= enemiesToSpawn.Length)
        {
            i = 0;
        }

        if(doOnce)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

        StartCoroutine("SpawnEnemies");
    }
}
