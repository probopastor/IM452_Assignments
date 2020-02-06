using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomBehaviorData : MonoBehaviour, ISubject
{
    private List<IObserver> observerList = new List<IObserver>();

    public float runSpeed = 10f;
    public float walkSpeed = 5f;

    public bool chasingPlayer;
    public bool switchEnemyMode;
    public bool canBeSwitched;

    public float movementSpeed = 0f;

    public float attackPhaseTimer = 100f;
    public float defensePhaseTimer = 100f;

    public float attackTimer;
    public float defenseTimer;

    private bool immuneToDamage;

    // Start is called before the first frame update
    void Start()
    {
        immuneToDamage = true;

        chasingPlayer = true;
        switchEnemyMode = false;
        canBeSwitched = false;

        attackTimer = attackPhaseTimer;
        defenseTimer = defensePhaseTimer;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canBeSwitched)
        {
            switchEnemyMode = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(chasingPlayer && attackTimer > 0)
        {
            attackTimer--;
            immuneToDamage = true;
            movementSpeed = runSpeed;

            NotifyObservers();
        }
        else if(chasingPlayer && attackTimer <= 0)
        {
            canBeSwitched = true;

            if(switchEnemyMode)
            {
                canBeSwitched = false;
                chasingPlayer = false;
                switchEnemyMode = false;
                attackTimer = attackPhaseTimer;
            }
        }

        if (!chasingPlayer && defenseTimer > 0)
        {
            defenseTimer--;
            immuneToDamage = false;
            movementSpeed = walkSpeed;

            NotifyObservers();
        }
        else if(!chasingPlayer && defenseTimer <= 0)
        {
            chasingPlayer = true;
            defenseTimer = defensePhaseTimer;
        }
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observerList)
        {
            observer.UpdateData(chasingPlayer, movementSpeed, immuneToDamage);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observerList.Add(observer);
        observer.UpdateData(chasingPlayer, movementSpeed, immuneToDamage);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observerList.Contains(observer))
        {
            observerList.Remove(observer);
        }
    }

}
