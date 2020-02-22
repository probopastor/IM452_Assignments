using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabSimpleFactory : MonoBehaviour
{
    public GameObject overEater;
    public GameObject hungryPeasant;
    public GameObject doughnutEatingInvoluntaryCelibate;
    public GameObject kyle;

    private GameObject enemy;

    public GameObject EnterCustomer(string enemyType)
    {
        enemy = null;

        if(enemyType.Equals("overEater"))
        {
            enemy = overEater;
        }
        else if(enemyType.Equals("hungryPeasant"))
        {
            enemy = hungryPeasant;
        }
        else if(enemyType.Equals("doughnutEatingInvoluntaryCelibate"))
        {
            enemy = doughnutEatingInvoluntaryCelibate;
        }
        else if(enemyType.Equals("kyle"))
        {
            enemy = kyle;
        }
        else
        {
            enemy = null;
        }

        Debug.Log("Factory sending: " + enemy);

        return enemy;
    }
}
