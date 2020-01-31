using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapBehaviorPlatforms : Platforms
{
    private bool doOnce; 

    // Start is called before the first frame update
    void Start()
    {
        doOnce = false;
        SetMovementType(gameObject.AddComponent(typeof(NoMovementBehavior)) as IMovementType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            if (!doOnce)
            {
                Debug.Log("COLLISION HAPPENED");
                doOnce = true;
                //switchPlatformBehaviors++;
            }
        }
        
    }
}
