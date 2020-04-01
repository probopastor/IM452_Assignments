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
        Debug.Log(" ");
    }

    public void BurnBehavior()
    {
        Debug.Log(" ");
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
        Debug.Log(" ");
    }

    public void StunBehavior()
    {
      //   
    }
}
