using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClient : MonoBehaviour
{
    public IEnemyState stunState;
    public IEnemyState burnState;
    public IEnemyState chaseState;
    public IEnemyState currentState;

    public int damageAmount = 1;
    public int health = 10;
    public float recoverTime = 2f;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        stunState = new StunState(this);
        burnState = new BurnState(this);
        chaseState = new ChaseState(this);
        currentState = chaseState;

        player = FindObjectOfType<PlayerController>();

        ChasePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChasePlayer()
    {
        currentState.StartChasing();
    }

    public void Burn()
    {
        currentState.CatchFire();
        StartCoroutine(RecoverFromAilment());
    }

    public void Stun()
    {
        currentState.BecomeStunned();
        StartCoroutine(RecoverFromAilment());
    }

    private IEnumerator RecoverFromAilment()
    {
        yield return new WaitForSeconds(recoverTime);
        currentState.Recover();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Occured ");

        if(collision.CompareTag("Sword"))
        {
            if(player.GetSwordPowerNumber() == 1)
            {
                Debug.Log("hit with 1 ");
                DecreaseHealth(player.GetSwordDamageAmount());
                ChasePlayer();
            }
            else if (player.GetSwordPowerNumber() == 2)
            {
                Debug.Log("hit with 2 ");
                DecreaseHealth(player.GetSwordBurnDamageAmount());
                Burn();
            }
            else if (player.GetSwordPowerNumber() == 3)
            {
                Debug.Log("hit with 3 ");
                DecreaseHealth(player.GetSwordStunDamageAmount());
                Stun();
            }
        }
        else if(collision.CompareTag("Player"))
        {
            player.DecreaseHealth(damageAmount);
        }
    }

    private void DecreaseHealth(int amount)
    {
        Debug.Log("Damage Taken"); 
        health -= amount;
        if(health <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
