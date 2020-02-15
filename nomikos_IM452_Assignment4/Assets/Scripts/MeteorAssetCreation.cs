/*
* William Nomikos
* MeteorAssetCreation.cs
* Assignment 4
* Script creates a MeteorController object to add decorators to
* upon the player colliding with items in game. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAssetCreation : MonoBehaviour
{
    public MeteorController myMeteor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DenseDebris"))
        {
            this.myMeteor = gameObject.AddComponent<DenseDebris>();
            UpdateMeteor();
        }

        if(collision.CompareTag("EmissiveAcceleration"))
        {
            this.myMeteor = gameObject.AddComponent<EmissiveAcceleration>();
            UpdateMeteor();
        }

        if (collision.CompareTag("MaterialRetraction"))
        {
            this.myMeteor = gameObject.AddComponent<MaterialRetraction>();
            UpdateMeteor();
        }
    }

    private void UpdateMeteor()
    {
        myMeteor.AddSize();
        myMeteor.AddSpeed();
    }
}
