/*
* William Nomikos
* RotateBehavior.cs
* Assignment 2
* Script handles the behavior for any object with RotateBehavior movement type.
* Rotates platforms at a given rotation speed. 
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
