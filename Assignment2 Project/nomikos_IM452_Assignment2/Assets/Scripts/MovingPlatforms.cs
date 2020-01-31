using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : Platforms
{

    private void Start()
    {
        SetMovementType(gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType);
        //SetBehaviorVariables();
        gameObject.GetComponent<LinearMovementBehavior>().xDirection = moveSpeed;
        gameObject.GetComponent<LinearMovementBehavior>().timeInDirection = linearDirectionTime;
    }
    
    /*
    private void Update()
    {
        if (switchPlatformBehaviors == 1)
        {
            switchPlatformBehaviors++;

            SetMovementType(this.gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType);
            //SetBehaviorVariables();
            gameObject.GetComponent<RotateBehavior>().rotationSpeed = spinSpeed;


        }
        else if (switchPlatformBehaviors >= 3)
        {
            SetMovementType(this.gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType);
            gameObject.GetComponent<LinearMovementBehavior>().xDirection = moveSpeed;
            gameObject.GetComponent<LinearMovementBehavior>().timeInDirection = linearDirectionTime;
            //SetBehaviorVariables();

            switchPlatformBehaviors = 0;
        }
    }*/
}
