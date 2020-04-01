using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    //void ChasePlayer();
    //void OnFire();
    //void Stunned();
    //void OriginalState();

    void StartChasing();
    void CatchFire();
    void BecomeStunned();
    void Recover();

}
