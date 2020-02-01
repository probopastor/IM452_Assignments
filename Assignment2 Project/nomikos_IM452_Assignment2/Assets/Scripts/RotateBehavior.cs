/*
* William Nomikos
* RotateRight.cs
* Assignment 2
* Script is the "has a" component for platforms that rotate in the right direction. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehavior : MonoBehaviour, IMovementType
{
    
    public float rotationSpeed = 0f;

    private void Update()
    {
        MovePattern();
    }

    public void MovePattern()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
}
