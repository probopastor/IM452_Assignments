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
