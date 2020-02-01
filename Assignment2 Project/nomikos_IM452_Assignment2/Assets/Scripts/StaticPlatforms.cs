/*
* William Nomikos
* StaticPlatforms.cs
* Assignment2
* Adds NoMovementBehavior to all static platforms.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlatforms : Platforms
{
    // Start is called before the first frame update
    void Start()
    {
        SetMovementType(gameObject.AddComponent(typeof(NoMovementBehavior)) as IMovementType);
    }
}
