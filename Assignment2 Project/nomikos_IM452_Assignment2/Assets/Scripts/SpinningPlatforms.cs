using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPlatforms : Platforms
{
    private void Start()
    {
        objectRotationDirection = new RotateLeft();
        SetRotationType(objectRotationDirection);

        Debug.Log("this direction: " + TryToRotate());

        objectRotationDirection = new RotateRight();
        SetRotationType(objectRotationDirection);

        Debug.Log("this direction 2: " + TryToRotate());

        objectRotationDirection = new NoRotation();
        SetRotationType(objectRotationDirection);

        Debug.Log("this direction 3: " + TryToRotate());
    }

}
