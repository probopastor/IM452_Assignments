using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeteorDecorator : MeteorController
{
    protected override abstract void SetPlayerSize(Vector3 newSize);
    protected abstract override void SetPlayerSpeed(float speed);
}
