/*
* William Nomikos
* DenseDebris.cs
* Assignment 4
* One of the decorators that can decorate the player meteor.
* This decorator makes the player larger but slowes their speed.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenseDebris : MeteorDecorator
{
    MeteorController meteor;

    public DenseDebris(MeteorController theMeteor)
    {
        this.meteor = theMeteor;
    }

    public override void AddSize()
    {
        transform.localScale = new Vector3((GetPlayerSize().x + 1f), (GetPlayerSize().y + 1f), 1);
    }

    public override void AddSpeed()
    {
        SetPlayerSpeed(1);

    }
}
