using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float projectileSpeed = 1f;

    public float damageOutput = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProjectileMovement(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //Damage enemy here if tag matches projectile
            Destroy(gameObject);
        }
    }
}
