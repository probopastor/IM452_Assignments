using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : Platforms
{

    private void Start()
    {
        SetMovementType(gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType);
        SetBehaviorVariables();
    }
    
    private void Update()
    {
        if (switchPlatformBehaviors == 1)
        {
            switchPlatformBehaviors++;

            SetMovementType(gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType);
            SetBehaviorVariables();

        }
        else if (switchPlatformBehaviors >= 3)
        {
            SetMovementType(gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType);
            SetBehaviorVariables();

            switchPlatformBehaviors = 0;
        }
    }
}
