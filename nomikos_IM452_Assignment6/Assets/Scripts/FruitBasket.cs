using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBasket : MonoBehaviour
{
    public int ammunitionAmount = 1;
    public int timeUntilDespawn = 9;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject != null)
        {
            Destroy(gameObject, timeUntilDespawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponentInChildren<ShootProjectile>().ChangeAmmunitionAmount(ammunitionAmount);

            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
