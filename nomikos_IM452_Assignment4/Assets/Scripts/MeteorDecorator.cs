using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeteorDecorator : MeteorController
{
    public abstract override void AddSize();
    public abstract override void AddSpeed();
}
