/*
* William Nomikos
* MeteorDecorator.cs
* Assignment 4
* Decorator class for meteors, forces subclass 
* decorator components to implement player size and speed
* methods.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeteorDecorator : MeteorController
{
    public abstract override void AddSize();
    public abstract override void AddSpeed();
}
