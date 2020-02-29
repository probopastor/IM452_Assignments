using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonProjectile : Projectiles
{
    public MelonProjectile()
    {
        this.projectileSpeed = 3f;
        this.damageOutput = 10f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x < -32.4f) || (transform.position.x > 32.4f) || (transform.position.y > 18.47f) || (transform.position.y < -13.71f))
        {
            Destroy(this.gameObject);
        }
    }
}
