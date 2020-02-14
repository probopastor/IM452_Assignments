using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float missileSpeed = 1f;
    public float damageOutput = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-missileSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -22)
        {
            Destroy(gameObject, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("thing 1 ");

        if(other.CompareTag("Player"))
        {
            Debug.Log("thing 2 ");

            MeteorController.currentPlayerHealth -= damageOutput;

            Destroy(gameObject);
        }
    }
}
