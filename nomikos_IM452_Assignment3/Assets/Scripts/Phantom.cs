using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantom : MonoBehaviour, IObserver
{
    private bool tankDamage;

    public PhantomBehaviorData phantomBehavior;
    public GameObject player;
    private Transform playerTransform;

    private IEnumerator moveTowardsCoroutine;
    private IEnumerator moveAwayCoroutine;

    bool moveTowardsPlayer;

    // Start is called before the first frame update
    void Start()
    {
        phantomBehavior.RegisterObserver(this);
        player = GameObject.Find("Player");
        playerTransform = player.transform;
        moveTowardsPlayer = false;


    }

    public void UpdateData(bool chasePlayer, float chaseSpeed, bool immuneToDamage)
    {
        tankDamage = immuneToDamage;

        if (chasePlayer)
        {
            if(moveAwayCoroutine != null)
            {
                StopCoroutine(moveAwayCoroutine);
            }
            moveTowardsPlayer = true;
            moveTowardsCoroutine = MovePhantomToPlayer(chaseSpeed);
            StartCoroutine(moveTowardsCoroutine);
        }
        else if (!chasePlayer)
        {
            if(moveTowardsCoroutine != null)
            {
                StopCoroutine(moveTowardsCoroutine);
            }
            moveTowardsPlayer = false;
            moveAwayCoroutine = MovePhantomAwayFromPlayer(chaseSpeed);
            StartCoroutine(moveAwayCoroutine);
        }

    }

    private IEnumerator MovePhantomToPlayer(float chaseSpeed)
    {
        yield return new WaitForSeconds(0.1f);
        if (moveTowardsPlayer)
        {
            moveTowardsCoroutine = MovePhantomToPlayer(chaseSpeed);

            Debug.Log("Moving Towards");


            //move to code here

            StartCoroutine(moveTowardsCoroutine);
        }
        
    }
    private IEnumerator MovePhantomAwayFromPlayer(float chaseSpeed)
    {
        yield return new WaitForSeconds(0.1f);

        if (!moveTowardsPlayer)
        {
            moveAwayCoroutine = MovePhantomAwayFromPlayer(chaseSpeed);

            Debug.Log("Moving Away");

            //move away code here

            StartCoroutine(moveAwayCoroutine);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!tankDamage)
            {
                Destroy(this.gameObject);
            }
            else if(tankDamage)
            {
                Time.timeScale = 0;
            }
        }
    }
}
