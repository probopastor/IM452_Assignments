/*
* William Nomikos
* HeartPickup.cs
* Assignment 6
* Script handles the Heart pickup item, which gives the player more health.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int healthAmount = 1;
    public int timeUntilDespawn = 9;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject != null)
        {
            Destroy(gameObject, timeUntilDespawn);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<ShipController>().DecreaseHealth(-healthAmount);

            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
