using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomBehaviorData : MonoBehaviour, ISubject
{
    private List<IObserver> observerList = new List<IObserver>();

    private string tagName = " ";
    private string attackTag = "AttackGhost";
    private string defenseTag = "DefenseGhost";

    public float runSpeed = 0f;
    public float walkSpeed = 0f;

    private bool chasingPlayer;
    private float movementSpeed = 0f;

    public float attackPhaseTimer = 100f;
    public float defensePhaseTimer = 100f;

    float attackTimer;
    float defenseTimer;

    // Start is called before the first frame update
    void Start()
    {
        chasingPlayer = true;
        tagName = attackTag;
        attackTimer = attackPhaseTimer;
        defenseTimer = defensePhaseTimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(chasingPlayer && attackTimer > 0)
        {
            attackTimer--;
            tagName = attackTag;
            movementSpeed = runSpeed;
        }
        else if(chasingPlayer && attackTimer <= 0)
        {
            chasingPlayer = false;
            attackTimer = attackPhaseTimer;
        }

        if(!chasingPlayer && defenseTimer > 0)
        {
            defenseTimer--;
            tagName = defenseTag;
            movementSpeed = walkSpeed;
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
            observer.UpdateData(chasingPlayer, movementSpeed, tagName);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observerList.Add(observer);
        observer.UpdateData(chasingPlayer, movementSpeed, tagName);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observerList.Contains(observer))
        {
            observerList.Remove(observer);
        }
    }

}
