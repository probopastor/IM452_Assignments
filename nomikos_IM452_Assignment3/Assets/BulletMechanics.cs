using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanics : MonoBehaviour
{
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();

        rend.material.SetColor("_Color", Color.red);

        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Phantom") || other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
