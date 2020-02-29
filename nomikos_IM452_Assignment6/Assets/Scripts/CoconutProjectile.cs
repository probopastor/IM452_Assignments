using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutProjectile : Projectiles
{
    public CoconutProjectile()
    {
        this.projectileSpeed = 6f;
        this.damageOutput = 8f;
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
