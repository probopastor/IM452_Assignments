/*
* William Nomikos
* BulletMechanics.cs
* Assignment 3
* This code handles the destruction of bullet prefabs, destroying them after
* a period of ntime or after triggering specific objects.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanics : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Phantom") || other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
