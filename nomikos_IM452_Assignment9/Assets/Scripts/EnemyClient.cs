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

    public float movementSpeed = 5f;

    private PlayerController player;

    public ParticleSystem burnParticles;
    private GameObject burnParticlesObj;

    private bool burnParticlesInstantiated = false;
    public float burnYModifier = 0f;
    public float burnXModifier = 0f;
    public float burnZModifier = 0f;

    public ParticleSystem stunParticles;
    private GameObject stunParticleObj;

    private bool stunParticlesInstantiated = false;
    public float stunYModifier = 0f;
    public float stunXModifier = 0f;
    public float stunZModifier = 0f;

    public AudioSource SoundEffectSource;
    public AudioClip damageSound;

    private WinManager winManager;

    // Start is called before the first frame update
    void Start()
    {
        stunState = new StunState(this);
        burnState = new BurnState(this);
        chaseState = new ChaseState(this);
        currentState = chaseState;

        player = FindObjectOfType<PlayerController>();
        winManager = FindObjectOfType<WinManager>();

        burnCounter = 0f;

        ChasePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    public void ChasePlayer()
    {
        currentState.StartChasing(movementSpeed * Time.deltaTime);
    }

    public void Burn()
    {
        currentState.CatchFire();
        StartCoroutine(BurnTime());
    }

    public void Stun()
    {
        currentState.BecomeStunned();
        StartCoroutine(StunTime());
    }
    private IEnumerator BurnTime()
    {
        if(!burnParticlesInstantiated)
        {
            burnParticlesInstantiated = true;
            Vector3 burnParticleLocation = new Vector3(gameObject.transform.position.x + burnXModifier, gameObject.transform.position.y + burnYModifier, gameObject.transform.position.z + burnZModifier);
            burnParticlesObj = Instantiate(burnParticles.gameObject, burnParticleLocation, Quaternion.Euler(-90f, 0f, 0f));
            burnParticlesObj.transform.parent = gameObject.transform;
            burnParticles.Play();
        }

        yield return new WaitForSeconds(burnDamageRate);
        burnCounter++;
        DecreaseHealth(1);
        
        if(burnCounter > burnRecoverTime)
        {
            burnCounter = 0;
            Destroy(burnParticlesObj);
            burnParticlesInstantiated = false;
            StartCoroutine(Recover());
        }
        else
        {
            StartCoroutine(BurnTime());
        }
    }

    private IEnumerator StunTime()
    {
        if (!stunParticlesInstantiated)
        {
            stunParticlesInstantiated = true;
            Vector3 stunParticleLocation = new Vector3(gameObject.transform.position.x + stunXModifier, gameObject.transform.position.y + stunYModifier, gameObject.transform.position.z + stunZModifier);
            stunParticleObj = Instantiate(stunParticles.gameObject, stunParticleLocation, Quaternion.Euler(0f, 0f, 0f));
            stunParticleObj.transform.parent = gameObject.transform;
            stunParticles.Play();
        }

        yield return new WaitForSeconds(stunRecoverTime);

        Destroy(stunParticleObj);
        stunParticlesInstantiated = false;
        StartCoroutine(Recover());
    }

    private IEnumerator Recover()
    {
        currentState.Recover();
        yield return new WaitForEndOfFrame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Sword"))
        {
            SoundEffectSource.clip = damageSound;
            SoundEffectSource.Play();

            if (player.GetSwordPowerNumber() == 1)
            {
                DecreaseHealth(player.GetSwordDamageAmount());
            }
            else if (player.GetSwordPowerNumber() == 2)
            {
                DecreaseHealth(player.GetSwordBurnDamageAmount());
                Burn();
            }
            else if (player.GetSwordPowerNumber() == 3)
            {
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
        health -= amount;
        if(health <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        winManager.UpdateScore();
        Destroy(gameObject);
    }
}
