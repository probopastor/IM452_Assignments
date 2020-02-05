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
            moveTowardsPlayer = true;
            moveTowardsCoroutine = MovePhantomToPlayer(chaseSpeed);
            StartCoroutine(moveTowardsCoroutine);
        }
        else if (!chasePlayer)
        {
            moveTowardsPlayer = false;
            moveAwayCoroutine = MovePhantomAwayFromPlayer(chaseSpeed);
            StartCoroutine(moveAwayCoroutine);
        }

    }

    private IEnumerator MovePhantomToPlayer(float chaseSpeed)
    {
        yield return new WaitForSeconds(0.1f);
        if (gameObject != null)
        {
            if (moveTowardsPlayer)
            {
                moveTowardsCoroutine = MovePhantomToPlayer(chaseSpeed);

                Debug.Log("Moving Towards");


                //move to code here

                StartCoroutine(moveTowardsCoroutine);
            }
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
        }


    }
    private IEnumerator MovePhantomAwayFromPlayer(float chaseSpeed)
    {
        yield return new WaitForSeconds(0.1f);

        if(gameObject != null)
        {
            if (!moveTowardsPlayer)
            {
                moveAwayCoroutine = MovePhantomAwayFromPlayer(chaseSpeed);

                Debug.Log("Moving Away");

                //move away code here

                StartCoroutine(moveAwayCoroutine);
            }
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!tankDamage)
            {
                phantomBehavior.RemoveObserver(this);
                Destroy(this.gameObject);
            }
            else if(tankDamage)
            {
                Time.timeScale = 0;
            }
        }
    }
}
