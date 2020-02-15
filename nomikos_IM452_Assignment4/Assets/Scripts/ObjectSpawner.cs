using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float timeUntilSpawn = 1f;
    public GameObject[] objectArray;
    private int objectIndex = 0;

    public static bool firstIt = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (firstIt)
        {
            firstIt = false;
            timeUntilSpawn -= 4;
            Debug.Log(timeUntilSpawn);
            if (timeUntilSpawn < 2)
            {
                timeUntilSpawn = 2;
            }
        }
    }

    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(timeUntilSpawn);

        int randomInt = Random.Range(0, 100);

        if(randomInt < 50)
        {
            objectIndex = 0;
        }
        else if(randomInt < 70)
        {
            objectIndex = 1;
        }
        else if(randomInt < 80)
        {
            objectIndex = 2;
        }
        else if(randomInt < 90)
        {
            objectIndex = 3;
        }
        else if(randomInt < 100)
        {
            objectIndex = 4;
        }
        
        if(objectArray[objectIndex] == null)
        {
            objectIndex = 0;
        }

        Instantiate(objectArray[objectIndex], gameObject.transform.position, Quaternion.identity);

        StartCoroutine("SpawnObject");
    }
}
