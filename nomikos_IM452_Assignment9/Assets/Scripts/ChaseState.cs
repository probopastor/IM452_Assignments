using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    EnemyClient enemyClient;

    public ChaseState(EnemyClient client)
    {
        this.enemyClient = client;
    }

    public void BecomeStunned()
    {
        Debug.Log("Enemy is stunned ");
        enemyClient.currentState = enemyClient.stunState;
    }

    public void CatchFire()
    {
        Debug.Log("Enemy is on fire ");
        enemyClient.currentState = enemyClient.burnState;
    }

    public void Recover()
    {
        Debug.Log(" ");
    }

    public void StartChasing()
    {
        Debug.Log("Enemy chasing player ");
        enemyClient.currentState = enemyClient.chaseState;
    }
}
