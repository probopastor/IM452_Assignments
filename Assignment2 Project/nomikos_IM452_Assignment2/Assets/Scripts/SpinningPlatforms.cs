using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPlatforms : Platforms
{
    private int switchPlatformBehaviors = 0;
    [SerializeField] private float count1 = 0.5f;
    [SerializeField] private float countDepletionRate = 1f;
    private float count2 = 0;

    private void Start()
    {
        count2 = count1;

        if(gameObject.GetComponent(typeof(RotateBehavior)) == null)
        {
            SetMovementType(gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType);
        }

        gameObject.GetComponent<RotateBehavior>().rotationSpeed = spinSpeed;
        //SetBehaviorVariables();
    }

    private void Update()
    {
        count2-= countDepletionRate;

        Debug.Log("1: " + switchPlatformBehaviors);

        if(switchPlatformBehaviors == 1)
        {
            Debug.Log("2: " + switchPlatformBehaviors);

            switchPlatformBehaviors++;

            Destroy(GetComponent<RotateBehavior>());

            SetMovementType(this.gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType);
            gameObject.GetComponent<LinearMovementBehavior>().xDirection = moveSpeed;
            gameObject.GetComponent<LinearMovementBehavior>().timeInDirection = linearDirectionTime;

        }
        else if(switchPlatformBehaviors >= 3)
        {
            Debug.Log("3: " + switchPlatformBehaviors);

            Destroy(GetComponent<LinearMovementBehavior>());

            SetMovementType(this.gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType);
            gameObject.GetComponent<RotateBehavior>().rotationSpeed = spinSpeed;

            switchPlatformBehaviors = 0;
        }
        Debug.Log("4: " + switchPlatformBehaviors);


        if(count2 <= 0)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                switchPlatformBehaviors++;
                count2 = count1;
            }
        }
    }

}
