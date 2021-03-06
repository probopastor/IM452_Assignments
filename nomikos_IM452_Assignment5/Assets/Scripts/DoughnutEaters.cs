﻿/*
* William Nomikos
* DoughnutEaters.cs
* Assignment 5
* Superclass for all doughnut eating enemies.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoughnutEaters : MonoBehaviour
{
    protected abstract void MoveToPlayer();
    protected abstract void TakeDamage();
    protected abstract void DealDamage();
}
