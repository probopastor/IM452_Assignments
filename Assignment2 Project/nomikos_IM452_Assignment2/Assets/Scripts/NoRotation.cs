using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotation : IRotationDirection
{
    public string RotatePlatform()
    {
        return "I don't rotate!";
    }
}
