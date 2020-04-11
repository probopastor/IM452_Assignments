using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : MonoBehaviour
{
    private GameObject player;
    public float forceMultiplier = 1f;
    private float randomForce = 0f;

    public bool targetPlayerDirectly;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        if(targetPlayerDirectly)
        {
            player = FindObjectOfType<PlayerMovement>().gameObject;
            Vector3 direction = player.transform.position - gameObject.transform.position;
            Vector3 force = new Vector3(direction.x * forceMultiplier, 0, direction.z * forceMultiplier);
            GetComponent<Rigidbody>().velocity = force;
        }
        else if(!targetPlayerDirectly)
        {
            randomForce = Random.Range(5, 11);

            player = FindObjectOfType<PlayerMovement>().gameObject;
            Vector3 direction = Random.onUnitSphere;
            Vector3 force = new Vector3(direction.x * randomForce, 0, direction.z * randomForce);
            GetComponent<Rigidbody>().velocity = force;
        }
     
    }
}
