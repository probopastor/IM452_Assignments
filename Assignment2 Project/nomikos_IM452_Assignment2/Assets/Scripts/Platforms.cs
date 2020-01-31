using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platforms : MonoBehaviour
{
    protected IMovementType objectMovementType;

    public static int switchPlatformBehaviors = 0; 

    public void SetMovementType(IMovementType movingObject)
    {
        objectMovementType = movingObject;
    }

}
