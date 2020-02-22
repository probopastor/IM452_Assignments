using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public string[] enemyWave1;
    public string[] enemyWave2;
    public string[] enemyWave3;

    public float spawnRateWave1 = 1f;
    public float spawnRateWave2 = 1f;
    public float spawnRateWave3 = 1f;

    public EnemyPrefabSimpleFactory enemyFactory;

    public float xSpawnMod = 0f;
    public float ySpawnMod = 0f;
    public float zSpawnMod = 0f;

    private GameObject thisEnemy;

    private bool waveStarted;


    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        waveStarted = false;
        StartCoroutine("EnemySpawning");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator EnemySpawning()
    {

        if (ButtonController.isClicked)
        {
            if (!waveStarted)
            {
                waveStarted = true;
                index = 0;
            }

            if (ButtonController.waveNumber == 1)
            {
                if(index < enemyWave1.Length)
                {
                    thisEnemy = enemyFactory.EnterCustomer(enemyWave1[index]);
                    Instantiate(thisEnemy, new Vector3(transform.position.x + xSpawnMod, transform.position.y + ySpawnMod, transform.position.z + zSpawnMod), Quaternion.identity);
                    index++;
                }
                else if(index < 0 || index > enemyWave1.Length)
                {
                    index = 0;
                }

                yield return new WaitForSeconds(spawnRateWave1);
            }
            else if (ButtonController.waveNumber == 2)
            {
                if (index < enemyWave2.Length)
                {
                    thisEnemy = enemyFactory.EnterCustomer(enemyWave2[index]);
                    Instantiate(thisEnemy, new Vector3(transform.position.x + xSpawnMod, transform.position.y + ySpawnMod, transform.position.z + zSpawnMod), Quaternion.identity);
                    index++;
                }
                else if (index < 0 || index > enemyWave2.Length)
                {
                    index = 0;
                }

                yield return new WaitForSeconds(spawnRateWave2);
            }
            else if (ButtonController.waveNumber == 3)
            {
                if (index < enemyWave3.Length)
                {
                    thisEnemy = enemyFactory.EnterCustomer(enemyWave3[index]);
                    Instantiate(thisEnemy, new Vector3(transform.position.x + xSpawnMod, transform.position.y + ySpawnMod, transform.position.z + zSpawnMod), Quaternion.identity);
                    index++;
                }
                else if (index < 0 || index > enemyWave3.Length)
                {
                    index = 0;
                }

                yield return new WaitForSeconds(spawnRateWave3);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            waveStarted = false;
        }

        yield return new WaitForSeconds(0.1f);
        StartCoroutine("EnemySpawning");
    }
}
