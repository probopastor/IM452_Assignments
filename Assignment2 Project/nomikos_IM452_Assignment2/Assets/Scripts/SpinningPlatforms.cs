using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPlatforms : Platforms
{
    private void Start()
    {
        SetMovementType(gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType);
        SetBehaviorVariables();
    }

    private void Update()
    {
        if(switchPlatformBehaviors == 1)
        {
            switchPlatformBehaviors++;

            Destroy(GetComponent<RotateBehavior>());

            SetMovementType(gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType);

            SetBehaviorVariables();

        }
        else if(switchPlatformBehaviors >= 3)
        {
            Destroy(GetComponent<LinearMovementBehavior>());

            SetMovementType(gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType);

            SetBehaviorVariables();

            switchPlatformBehaviors = 0;
        }
    }

}
