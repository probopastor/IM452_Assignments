using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryProjectile : Projectiles
{
    public StrawberryProjectile()
    {
        this.projectileSpeed = 25f;
        this.damageOutput = 0.25f;
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
