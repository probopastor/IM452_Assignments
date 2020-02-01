/*
* William Nomikos
* MovingPlatforms.cs
* Assignment2
* Handles switching the behavior of the moving platforms platforms at runtime 
* when the player left clicks when timer count1 is at 0.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : Platforms
{
    private int switchPlatformBehaviors = 0;

    private float count1 = 200f;
    private float countDepletionRate = 0.5f;
    private float count2 = 0;

    private void Start()
    {
        count2 = count1;
        SetMovementType(gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType);
        gameObject.GetComponent<LinearMovementBehavior>().xDirection = moveSpeed;
        gameObject.GetComponent<LinearMovementBehavior>().timeInDirection = linearDirectionTime;
    }
    
    
    private void Update()
    {
        count2 -= countDepletionRate;

        if (switchPlatformBehaviors == 1)
        {
            switchPlatformBehaviors++;

            Destroy(GetComponent<LinearMovementBehavior>());
            SetMovementType(this.gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType);
            gameObject.GetComponent<RotateBehavior>().rotationSpeed = spinSpeed;


        }
        else if (switchPlatformBehaviors >= 3)
        {
            Destroy(GetComponent<RotateBehavior>());
            SetMovementType(this.gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType);
            gameObject.GetComponent<LinearMovementBehavior>().xDirection = moveSpeed;
            gameObject.GetComponent<LinearMovementBehavior>().timeInDirection = linearDirectionTime;

            switchPlatformBehaviors = 0;
        }


        if (count2 <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                switchPlatformBehaviors++;
                count2 = count1;
            }
        }
    }
}
