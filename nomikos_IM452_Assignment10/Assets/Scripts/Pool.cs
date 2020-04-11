/*
* William Nomikos
* Pool.cs
* Assignment 10
* Interface creates parameters for each object pool.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int size;
}
