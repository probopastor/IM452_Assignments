using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPlatforms : Platforms
{
    public float spinSpeed = 0f;

    private void Start()
    {
        objectMovementType = gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType;
    }

    private void Update()
    {
        if(switchPlatformBehaviors == 1)
        {
            switchPlatformBehaviors++;

            Destroy(GetComponent<RotateBehavior>());

            objectMovementType = gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType;
            gameObject.GetComponent<LinearMovementBehavior>().xDirection = spinSpeed;

        }
        else if(switchPlatformBehaviors >= 3)
        {
            Destroy(GetComponent<LinearMovementBehavior>());
            objectMovementType = gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType;

            switchPlatformBehaviors = 0;
        }
    }

}
