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
        transform.localScale = new Vector3((GetPlayerSize().x + 0.5f), (GetPlayerSize().y + 0.5f), 1);
    }

    public override void AddSpeed()
    {
        playerSpeed = GetPlayerSpeed() - 1;
    }
}
