using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : IEnemyState
{
    EnemyClient enemyClient;

    public StunState(EnemyClient client)
    {
        this.enemyClient = client;
    }

    public void BecomeStunned()
    {
        throw new System.NotImplementedException();
    }

    public void CatchFire()
    {
        throw new System.NotImplementedException();
    }

    public void Recover()
    {
        Debug.Log("Enemy recovers ");
        enemyClient.currentState = enemyClient.chaseState;
    }

    public void StartChasing()
    {
        throw new System.NotImplementedException();
    }
}
