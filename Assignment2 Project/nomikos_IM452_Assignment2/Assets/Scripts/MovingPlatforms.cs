using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : Platforms
{
    private void Start()
    {
        objectMovementType = gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType;
        SetMovementType(objectMovementType);
    }
    
    private void Update()
    {
        if (switchPlatformBehaviors == 1)
        {
            switchPlatformBehaviors++;
            objectMovementType = gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType;
            SetMovementType(objectMovementType);

        }
        else if (switchPlatformBehaviors >= 3)
        {
            switchPlatformBehaviors = 0;

            objectMovementType = gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType;
            SetMovementType(objectMovementType);
        }
    }
}
