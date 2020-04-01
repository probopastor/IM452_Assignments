using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    EnemyClient enemyClient;
    PlayerController playerObject;

    public ChaseState(EnemyClient client)
    {
        this.enemyClient = client;
        playerObject = GameObject.FindObjectOfType<PlayerController>();
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

    public void StartChasing(float movementSpeed)
    {
        enemyClient.transform.position = Vector3.MoveTowards(enemyClient.transform.position, playerObject.transform.position, movementSpeed);
        enemyClient.currentState = enemyClient.chaseState;
    }
}
