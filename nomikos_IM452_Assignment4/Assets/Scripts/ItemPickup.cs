using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float itemSpeed = 1f;
    void Update()
    {
        transform.position += new Vector3(-itemSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -22)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
