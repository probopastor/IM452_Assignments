/*
* William Nomikos
* MaterialRetraction.cs
* Assignment 4
* One of the decorators that can decorate the player meteor.
* This decorator drastically decreases the player's size.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialRetraction : MeteorDecorator
{
    MeteorController meteor;

    public MaterialRetraction(MeteorController theMeteor)
    {
        this.meteor = theMeteor;
    }

    public override void AddSize()
    {
        if(transform.localScale.x >= 0.5  && transform.localScale.y >= 0.5)
        {
            transform.localScale = new Vector3((GetPlayerSize().x - 1f), (GetPlayerSize().y - 1f), 1);

            if(transform.localScale.x < 0.25 || transform.localScale.y < 0.25)
            {
                transform.localScale = new Vector3(0.25f, 0.25f, 1);
            }
        }
    }

    public override void AddSpeed()
    {
        SetPlayerSpeed(5f);
    }
}
