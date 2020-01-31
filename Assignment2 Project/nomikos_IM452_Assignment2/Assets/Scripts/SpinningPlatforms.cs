using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPlatforms : Platforms
{
   // public int switchPlatformBehaviors = 0;

   // float count1 = 0f;
    //float count2 = 0;

    private void Start()
    {
        //count1 = 10f;
       // count2 = count1;
        //objectMovementType2 = this.gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType;
        if(gameObject.GetComponent(typeof(RotateBehavior)) == null)
        {
            SetMovementType(gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType);
        }

        gameObject.GetComponent<RotateBehavior>().rotationSpeed = spinSpeed;
        //SetBehaviorVariables();
    }

    private void Update()
    {
        //count2-= 0.5f;
        //Debug.Log("count2 " + count2 + "count1 " + count1);

        Debug.Log("1: " + switchPlatformBehaviors);

        if(switchPlatformBehaviors == 1)
        {
            Debug.Log("2: " + switchPlatformBehaviors);

            switchPlatformBehaviors++;

            Destroy(GetComponent<RotateBehavior>());

            //objectMovementType2 = this.gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType;

            SetMovementType(this.gameObject.AddComponent(typeof(LinearMovementBehavior)) as IMovementType);
            gameObject.GetComponent<LinearMovementBehavior>().xDirection = moveSpeed;
            gameObject.GetComponent<LinearMovementBehavior>().timeInDirection = linearDirectionTime;

            //SetBehaviorVariables();

        }
        else if(switchPlatformBehaviors >= 3)
        {
            Debug.Log("3: " + switchPlatformBehaviors);

            Destroy(GetComponent<LinearMovementBehavior>());

            //objectMovementType2 = gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType;

            SetMovementType(this.gameObject.AddComponent(typeof(RotateBehavior)) as IMovementType);
            gameObject.GetComponent<RotateBehavior>().rotationSpeed = spinSpeed;

            // SetBehaviorVariables();


            switchPlatformBehaviors = 0;
        }
        Debug.Log("4: " + switchPlatformBehaviors);


       // if(count2 <= 0)
       // {
        //    switchPlatformBehaviors++;
       //     count2 = count1;
       // }
    }

}
