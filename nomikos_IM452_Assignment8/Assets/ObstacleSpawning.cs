using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawning : MonoBehaviour
{
    public GameObject[] obstacleArray;
    public Vector3[] spawnPos;
    public float[] obstacleSpawningTime;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstaclePatterns");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnObstaclePatterns()
    {
        index = Random.Range(0, obstacleArray.Length);

        yield return new WaitForSeconds(1f);
        Instantiate(obstacleArray[index], new Vector3(gameObject.transform.position.x, spawnPos[index].y, spawnPos[index].z), Quaternion.identity);
        yield return new WaitForSeconds(obstacleSpawningTime[index]);
        StartCoroutine("SpawnObstaclePatterns");
    }
}
