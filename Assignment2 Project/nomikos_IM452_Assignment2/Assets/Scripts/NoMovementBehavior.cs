/*
* William Nomikos
* NoMovementBehavior.cs
* Assignment 2
* Script handles the behavior for any object with NoMovementBehavior movement type.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMovementBehavior : MonoBehaviour, IMovementType
{
    private bool doOnce;

    private void Update()
    {
        if (!doOnce)
        {
            doOnce = true;
            MovePattern();
        }
    }

    public void MovePattern()
    {
        return;
    }
}
