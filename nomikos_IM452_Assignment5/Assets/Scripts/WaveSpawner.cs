using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public ButtonController gameButton;

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

    private int index = 0;
    private int index2 = 0;
    private int index3 = 0;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        index2 = 0;
        index3 = 0;
        StartCoroutine("EnemySpawning");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator EnemySpawning()
    {

        if (gameButton.GetComponent<ButtonController>().isClicked)
        {
            if (gameButton.GetComponent<ButtonController>().waveNumber == 1)
            {
                if(index < enemyWave1.Length)
                {
                    thisEnemy = enemyFactory.EnterCustomer(enemyWave1[index]); 
                    if (thisEnemy != null)
                    {
                        Instantiate(thisEnemy, new Vector3(transform.position.x + xSpawnMod, transform.position.y + ySpawnMod, transform.position.z + zSpawnMod), Quaternion.identity);
                    }
                    index++;
                }
                else if(index < 0 || index > enemyWave1.Length)
                {
                    index = 0;
                }

                yield return new WaitForSeconds(spawnRateWave1);
            }
            else if (gameButton.GetComponent<ButtonController>().waveNumber == 2)
            {
                if (index2 < enemyWave2.Length)
                {
                    thisEnemy = enemyFactory.EnterCustomer(enemyWave2[index2]);
                    if(thisEnemy != null)
                    {
                        Instantiate(thisEnemy, new Vector3(transform.position.x + xSpawnMod, transform.position.y + ySpawnMod, transform.position.z + zSpawnMod), Quaternion.identity);
                    }
                    index2++;
                }
                else if (index2 < 0 || index2 > enemyWave2.Length)
                {
                    index2 = 0;
                }

                yield return new WaitForSeconds(spawnRateWave2);
            }
            else if (gameButton.GetComponent<ButtonController>().waveNumber == 3)
            {
                if (index3 < enemyWave3.Length)
                {
                    thisEnemy = enemyFactory.EnterCustomer(enemyWave3[index3]); 
                    if (thisEnemy != null)
                    {
                        Instantiate(thisEnemy, new Vector3(transform.position.x + xSpawnMod, transform.position.y + ySpawnMod, transform.position.z + zSpawnMod), Quaternion.identity);
                    }
                    index3++;
                }
                else if (index3 < 0 || index3 > enemyWave3.Length)
                {
                    index3 = 0;
                }

                yield return new WaitForSeconds(spawnRateWave3);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }

        yield return new WaitForSeconds(0.1f);
        StartCoroutine("EnemySpawning");
    }
}
