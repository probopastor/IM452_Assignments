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

    public float stunRecoverTime = 2f;
    public float burnRecoverTime = 4f;
    private float burnCounter = 0f;

    public float burnDamageRate = 1f;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        stunState = new StunState(this);
        burnState = new BurnState(this);
        chaseState = new ChaseState(this);
        currentState = chaseState;

        player = FindObjectOfType<PlayerController>();

        burnCounter = 0f;

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
        currentState.BurnBehavior();
        StartCoroutine(BurnTime());
    }

    public void Stun()
    {
        currentState.BecomeStunned();
        currentState.StunBehavior();
        StartCoroutine(StunTime());
    }
    private IEnumerator BurnTime()
    {
        yield return new WaitForSeconds(burnDamageRate);
        burnCounter++;
        DecreaseHealth(1);
        
        if(burnCounter > burnRecoverTime)
        {
            burnCounter = 0;
            StartCoroutine(Recover());
        }
        else
        {
            StartCoroutine(BurnTime());
        }
    }

    private IEnumerator StunTime()
    {
        yield return new WaitForSeconds(stunRecoverTime);
        StartCoroutine(Recover());
    }

    private IEnumerator Recover()
    {
        currentState.Recover();
        yield return new WaitForEndOfFrame();
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
