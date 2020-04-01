using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnState : IEnemyState
{
    EnemyClient enemyClient;
    PlayerController playerObject;

    public BurnState(EnemyClient client)
    {
        this.enemyClient = client;
        playerObject = GameObject.FindObjectOfType<PlayerController>();
    }

    public void BecomeStunned()
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

    public void StartChasing(float movementSpeed)
    {
        enemyClient.transform.position = Vector3.MoveTowards(enemyClient.transform.position, playerObject.transform.position, movementSpeed);
        enemyClient.currentState = enemyClient.chaseState;
    }
}
