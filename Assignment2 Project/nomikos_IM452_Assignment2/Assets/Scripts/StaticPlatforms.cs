using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlatforms : Platforms
{
    // Start is called before the first frame update
    void Start()
    {
        objectMovementType = gameObject.AddComponent(typeof(NoMovementBehavior)) as IMovementType;
        SetMovementType(objectMovementType);
    }
}
