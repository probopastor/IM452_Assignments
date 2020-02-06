using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomBehaviorData : MonoBehaviour, ISubject
{
    private List<IObserver> observerList = new List<IObserver>();

    public AudioSource SoundEffectSource;
    public AudioClip damagePlayerSound;

    private Color phantomColor = new Color(0,0,0);

    public float damageRate = 0f;

    public Color attackColor;
    public Color runColor;

    public float runSpeed = 10f;
    public float walkSpeed = 5f;

    private bool chasingPlayer;
    private bool switchEnemyMode;
    private bool canBeSwitched;

    private float movementSpeed = 0f;

    public float attackPhaseTimer = 100f;
    public float defensePhaseTimer = 100f;

    private float attackTimer = 0f;
    private float defenseTimer = 0f;

    private bool immuneToDamage;

    // Start is called before the first frame update
    void Start()
    {
        phantomColor = attackColor;

        immuneToDamage = true;

        chasingPlayer = true;
        switchEnemyMode = false;
        canBeSwitched = false;

        attackTimer = attackPhaseTimer;
        defenseTimer = defensePhaseTimer;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && canBeSwitched)
        {
            switchEnemyMode = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeUntilBehaviorSwitch.timeRemaining = attackTimer;

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
                phantomColor = runColor;
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
            phantomColor = attackColor;
            defenseTimer = defensePhaseTimer;
        }
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observerList)
        {
            observer.UpdateData(chasingPlayer, movementSpeed, immuneToDamage, phantomColor, damageRate, SoundEffectSource, damagePlayerSound);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observerList.Add(observer);
        observer.UpdateData(chasingPlayer, movementSpeed, immuneToDamage, phantomColor, damageRate, SoundEffectSource, damagePlayerSound);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observerList.Contains(observer))
        {
            observerList.Remove(observer);
        }
    }

}
