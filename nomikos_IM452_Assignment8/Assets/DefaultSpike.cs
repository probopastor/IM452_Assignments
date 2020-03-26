using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpike : SpikeSuperclass
{
    public float movementSpeed = 1f;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        PreformAction();
    }

    public override void MoveSpike()
    {
        transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -20.94)
        {
            Destroy(gameObject);
        }
    }

    public override bool IsFirstDimension()
    {
        if(player.isDimension1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
