using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileTypeDecorator : Missile
{
    public override abstract void SetDamage();

    public override abstract void SetSize();

    public override abstract void SetSpeed();
}
