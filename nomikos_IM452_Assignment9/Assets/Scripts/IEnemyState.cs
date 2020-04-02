/*
* William Nomikos
* IEnemyState.cs
* Assignment 9
* Interface for state methods that is implemented by concrete states
* an enemy may be in. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void StartChasing(float movementSpeed);
    void CatchFire();
    void BecomeStunned();
    void Recover();
}
