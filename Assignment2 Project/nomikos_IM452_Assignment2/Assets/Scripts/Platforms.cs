using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platforms : MonoBehaviour
{
    public IRotationDirection objectRotationDirection;

    public string TryToRotate()
    {
        return objectRotationDirection.RotatePlatform();
    }

    public void SetRotationType(IRotationDirection rotatingObject)
    {
        objectRotationDirection = rotatingObject;
    }

}
