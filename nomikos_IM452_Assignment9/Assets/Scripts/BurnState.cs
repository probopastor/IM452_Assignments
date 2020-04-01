using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnState : IEnemyState
{
    EnemyClient enemyClient;

    public BurnState(EnemyClient client)
    {
        this.enemyClient = client;
    }

    public void BecomeStunned()
    {
        Debug.Log(" ");
    }

    public void BurnBehavior()
    {
        //
    }

    public void CatchFire()
    {
        Debug.Log(" ");
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

    public void StunBehavior()
    {
        Debug.Log(" ");
    }
}
