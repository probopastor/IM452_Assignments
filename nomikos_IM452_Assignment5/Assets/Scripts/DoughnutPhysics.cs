/*
* William Nomikos
* DoughnutPhysics.cs
* Assignment 5
* Handles doughnut projectiles sound, collision, and particles.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughnutPhysics : MonoBehaviour
{
    public ParticleSystem doughnutParticles;
    GameObject doughnutParticlesObj;
    public float yParticleModifier = 0f;
    public AudioSource SoundEffectSource;
    public AudioClip doughnutSplat;

    private void Start()
    {
        SoundEffectSource = GameObject.Find("Directional Light").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("Ground")) || (other.CompareTag("Enemy")))
        {
            SoundEffectSource.clip = doughnutSplat;
            SoundEffectSource.Play();

            Vector3 doughnutParticleLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + yParticleModifier, gameObject.transform.position.z);
            doughnutParticlesObj = Instantiate(doughnutParticles.gameObject, doughnutParticleLocation, Quaternion.Euler(-90f, 0f, 0f));
            doughnutParticles.Play();

            Destroy(doughnutParticlesObj, 3f);

            Destroy(gameObject);
        }
    }
}
