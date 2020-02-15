/*
* William Nomikos
* EmissiveAcceleration.cs
* Assignment 4
* One of the decorators that can decorate the player meteor.
* This decorator makes the player faster and slightly increases
* their size.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissiveAcceleration : MeteorDecorator
{
    MeteorController meteor;

    public EmissiveAcceleration(MeteorController theMeteor)
    {
        this.meteor = theMeteor;
    }

    public override void AddSize()
    {
        transform.localScale = new Vector3((GetPlayerSize().x + 0.25f), (GetPlayerSize().y + 0.25f), 1);
    }

    public override void AddSpeed()
    {
        SetPlayerSpeed(50);
    }
}
