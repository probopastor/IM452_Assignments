/*
* William Nomikos
* CleanUpObstacle.cs
* Assignment 8
* Destroys obstacle prefab clones after a period of time to prevent game lag.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpObstacle : MonoBehaviour
{
    public float destructionTime = 35f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destructionTime);
    }
}
