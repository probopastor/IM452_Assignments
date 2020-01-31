using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platforms : MonoBehaviour
{
    protected IMovementType objectMovementType;

    public static int switchPlatformBehaviors = 0;

    protected float spinSpeed = 5f;
    protected float moveSpeed = 5f;
    protected float linearDirectionTime = 2f;

    public void SetMovementType(IMovementType movingObject)
    {
        objectMovementType = movingObject;
    }

    public void SetBehaviorVariables()
    {
        if (gameObject.GetComponent<RotateBehavior>() != null)
        {
            gameObject.GetComponent<RotateBehavior>().rotationSpeed = spinSpeed;
        }

        if (gameObject.GetComponent<LinearMovementBehavior>() != null)
        {
            gameObject.GetComponent<LinearMovementBehavior>().xDirection = moveSpeed;
            gameObject.GetComponent<LinearMovementBehavior>().timeInDirection = linearDirectionTime;
        }
    }
}
