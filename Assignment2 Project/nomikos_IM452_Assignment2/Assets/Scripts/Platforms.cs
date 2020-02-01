/*
* William Nomikos
* Platforms.cs
* Assignment2
* The superclass that handles all platform objects. Uses IMovementType interface
* to set the movement type (object behavior) for platforms.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platforms : MonoBehaviour
{
    protected IMovementType objectMovementType;

    protected float spinSpeed = -1f;
    protected float moveSpeed = 5f;
    protected float linearDirectionTime = 2f;

    public void SetMovementType(IMovementType movingObject)
    {
        objectMovementType = movingObject;
    }
}
