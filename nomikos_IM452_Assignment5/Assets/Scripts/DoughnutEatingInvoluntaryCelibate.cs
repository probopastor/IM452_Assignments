using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughnutEatingInvoluntaryCelibate : DoughnutEaters
{
    public float speed = 1;
    public float health = 1f;
    private float currentHealth = 0f;
    public int damageRate = 1;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }
    protected override void DealDamage()
    {
        player.GetComponent<PlayerMovement>().DecreaseHealth(damageRate);
    }

    protected override void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    protected override void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Doughnut")
        {
            TakeDamage();
        }

        if (collision.gameObject.tag == "Player")
        {
            DealDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Doughnut"))
        {
            TakeDamage();
        }
    }
}
