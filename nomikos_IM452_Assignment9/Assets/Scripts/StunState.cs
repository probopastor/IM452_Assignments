/*
* William Nomikos
* StunState.cs
* Assignment 9
* Concrete state for stunned enemies. Is the set state when an enemy is stunned by the player's sword.
* Enemies in this state cannot move. 
*/

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
        Debug.Log(" ");
    }
}
