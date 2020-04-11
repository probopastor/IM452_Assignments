/*
* William Nomikos
* FrogBehavior.cs
* Assignment 10
* Controls the behavior for the frog boss, including its attacks and its movements.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehavior : MonoBehaviour
{
    private ObjectPooler objectPooler;

    public int firstAttackSize = 10;
    public int secondAttackSize = 10;
    public int thirdAttackSize = 10;

    public float rotationSpeed = 1f;

    private GameObject player;

    public int attackIndex = 0;
    private bool doOnce;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.instance;
        player = FindObjectOfType<PlayerMovement>().gameObject;

        doOnce = false;
        StartCoroutine(AttackChooser());
    }

    void Update()
    {
        Vector3 direction = player.transform.position - gameObject.transform.position;
        Quaternion rot = Quaternion.LookRotation(-direction);
        Quaternion newRot = new Quaternion(0, rot.y, 0, rot.w);
        gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator AttackChooser()
    {
        if(!doOnce)
        {
            yield return new WaitForSeconds(1f);
            doOnce = true;
        }

        attackIndex = Random.Range(0, 3);

        if (attackIndex == 0)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(FirstAttack());
        }
        else if(attackIndex == 1)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(SecondAttack());
        }
        else if(attackIndex == 2)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(ThirdAttack());
        }
        else
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(AttackChooser());
        }

        yield return new WaitForEndOfFrame();
    }
     
    private IEnumerator FirstAttack()
    {
        for (int i = 0; i < firstAttackSize; i++)
        {
            objectPooler.SpawnFromPool("NormalProjectile", new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }

        yield return new WaitForSeconds(2f);

        NormalProjectile[] normalProjectiles = FindObjectsOfType<NormalProjectile>();
        for (int i = 0; i < normalProjectiles.Length; i++)
        {
            objectPooler.ReturnObjectToPool("NormalProjectile", normalProjectiles[i].gameObject);
        }

        StartCoroutine(AttackChooser());
    }

    private IEnumerator SecondAttack()
    {
        for (int i = 0; i < secondAttackSize; i++)
        {
            objectPooler.SpawnFromPool("FastProjectile", new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }

        yield return new WaitForSeconds(2f);

        NormalProjectile[] normalProjectiles = FindObjectsOfType<NormalProjectile>();
        for (int i = 0; i < normalProjectiles.Length; i++)
        {
            objectPooler.ReturnObjectToPool("FastProjectile", normalProjectiles[i].gameObject);
        }

        StartCoroutine(AttackChooser());
    }

    private IEnumerator ThirdAttack()
    {
        for (int i = 0; i < thirdAttackSize; i++)
        {
            objectPooler.SpawnFromPool("FlameProjectile", new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(0.001f);
        }

        yield return new WaitForSeconds(10f);

        NormalProjectile[] normalProjectiles = FindObjectsOfType<NormalProjectile>();

        for (int i = 0; i < normalProjectiles.Length; i++)
        {
            objectPooler.ReturnObjectToPool("FlameProjectile", normalProjectiles[i].gameObject);
        }

        StartCoroutine(AttackChooser());
    }
}
