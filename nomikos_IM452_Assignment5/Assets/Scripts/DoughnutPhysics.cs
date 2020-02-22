using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughnutPhysics : MonoBehaviour
{
    public ParticleSystem doughnutParticles;
    GameObject doughnutParticlesObj;
    public float yParticleModifier = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("Ground")) || (other.CompareTag("Enemy")))
        {
            Vector3 doughnutParticleLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + yParticleModifier, gameObject.transform.position.z);
            doughnutParticlesObj = Instantiate(doughnutParticles.gameObject, doughnutParticleLocation, Quaternion.Euler(-90f, 0f, 0f));
            doughnutParticles.Play();

            Destroy(doughnutParticlesObj, 3f);

            Destroy(gameObject);
        }
    }
}
